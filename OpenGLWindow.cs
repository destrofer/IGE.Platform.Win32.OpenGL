/*
 * Author: Viacheslav Soroka
 * 
 * This file is part of IGE <https://github.com/destrofer/IGE>.
 * 
 * IGE is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * IGE is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with IGE.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using IGE.Graphics.OpenGL;
using IGE.Graphics;

using IGE.Platform.Win32;

namespace IGE.Platform {
	public partial class OpenGLWindow : Win32NativeWindow, IOpenGLWindow {
		private DeviceContext m_DeviceContext = null;
		public DeviceContext DeviceContext { get { return m_DeviceContext; } }
		
		private IResourceContext m_ResourceContext = null;
		public IResourceContext ResourceContext { get { return m_ResourceContext; } }

		public event BeforeRenderFrameEventHandler BeforeRenderFrameEvent;
		public event RenderFrameEventHandler RenderFrameEvent;
		public event AfterRenderFrameEventHandler AfterRenderFrameEvent;
		
		public OpenGLWindow(INativeWindow parent, int x, int y, int width, int height) : base(new WindowCreateStruct {
				WindowTitle = GameConfig.GameWindowTitle, //"IGE OpenGLWindow",
				X = x,
				Y = y,
				Width = width,
				Height = height,
				Style = GameConfig.FullScreen ? WindowStyleFlags.Popup : Win32NativeWindow.DefaultStyle,
				ExStyle = ExtendedWindowStyleFlags.ApplicationWindow,
				ParentWindow = (Win32NativeWindow)parent,
				Menu = IntPtr.Zero,
				Param = IntPtr.Zero,
	
				ClassName = "IGEOpenGLWindow",
				ClassStyle = WindowClassStyle.HREDRAW | WindowClassStyle.VREDRAW | WindowClassStyle.OWNDC,
				Background = (IntPtr)0, // no background brush is needed since opengl has its own renderer
				Icon = (GameConfig.IconResourceId != 0) ? IGE.Platform.Win32.API.Externals.LoadIcon(Win32Application.GetInstanceHandle(), (IntPtr)GameConfig.IconResourceId) : IGE.Platform.Win32.API.Externals.LoadIcon(IntPtr.Zero, (IntPtr)32512), // 32512 = IDI_APPLICATION
				Cursor = IGE.Platform.Win32.API.Externals.LoadCursor(IntPtr.Zero, (IntPtr)32512), // 32512 = IDC_ARROW
				ClassMenu = IntPtr.Zero,
				ClassExtra = 0,
				WindowExtra = 0
			})
		{
			m_DeviceContext = null;
			if( !Exists )
				return;

			m_DeviceContext = new DeviceContext(this);
			if( m_DeviceContext.Disposed ) {
				GameDebugger.EngineLog(LogLevel.Error, "Failed to properly create a device context");
				throw new UserFriendlyException("Failed to properly create a device context", "Graphics initialization error");
			}
			
			/*
			// This enumerates all pixel formats, supported by the device context to the log file
			for( int i = PixelFormat.GetCount(m_DeviceContext); i > 0; i-- ) {
				PixelFormat dpf = new PixelFormat(m_DeviceContext, i);
				GameDebugger.Log(dpf);
			}
			*/
			
			// change pixelformat for the window's device context
			//  | PixelFormatDescriptorFlags.SWAP_EXCHANGE
			PixelFormatDescriptor pfd = new PixelFormatDescriptor {
				Flags = PixelFormatDescriptorFlags.DOUBLEBUFFER | PixelFormatDescriptorFlags.SUPPORT_OPENGL | PixelFormatDescriptorFlags.DRAW_TO_WINDOW,
				PixelType = ApiPixelType.RGBA,
				ColorBits = (byte)GameConfig.ColorBits,
				RedBits = 8, GreenBits = 8, BlueBits = 8, AlphaBits = 8,
				RedShift = 0, GreenShift = 0, BlueShift = 0, AlphaShift = 0,
				DepthBits = (byte)GameConfig.DepthBufferBits,
				StencilBits = (byte)GameConfig.StencilBufferBits,
				AccumBits = (byte)GameConfig.AccumBufferBits, AccumRedBits = 0, AccumGreenBits = 0, AccumBlueBits = 0, AccumAlphaBits = 0,
				AuxBuffers = 0, LayerType = 0, LayerMask = 0, VisibleMask = 0, DamageMask = 0
			};

			PixelFormat pf = new PixelFormat(m_DeviceContext, ref pfd);
			
			GameDebugger.EngineLog(LogLevel.Debug, "{0}", pf);
			
			if( !pf.Exists )
				throw new Exception("Could not find a suitable pixel format for an OpenGL window.");
			
			bool res = pf.Apply();
			//GameDebugger.Log("Chosen: {0} {1}", pf.Exists, pf.ToString());
			//GameDebugger.Log("Apply result: {0}", res);
			if( !res ) {
				GameDebugger.EngineLog(LogLevel.Debug, "Failed applying requested pixel format, trying to apply by a found index");
				
				PixelFormat pf2 = new PixelFormat(m_DeviceContext, pf.Index);

				GameDebugger.EngineLog(LogLevel.Debug, "{0}", pf2);

				res = pf2.Apply();
				//GameDebugger.Log("Real: {0} {1}", pf2.Exists, pf2.ToString());
				//GameDebugger.Log("Apply result: {0}", res);
				if( !res )
					throw new Exception(String.Format("Error trying to set {0}", pf2.ToString()));
			}
			
			m_ResourceContext = new ResourceContext(m_DeviceContext);
			if( m_ResourceContext.Disposed ) {
				int pixelFormats = PixelFormat.GetCount(m_DeviceContext);
				GameDebugger.EngineLog(LogLevel.Debug, "Supported pixel formats:");
				for( int i = 0; i < pixelFormats; i++ ) {
					pf = new PixelFormat(m_DeviceContext, i);
					GameDebugger.EngineLog(LogLevel.Debug, "{0}", pf);
				}
				throw new Exception("Could not create a resource context for the OpenGLWindow");
			}
			m_ResourceContext.Activate();
			
			// "reload" because we want context specific extension functions to be loaded as well
			WGL.RuntimeImport();
			GL.RuntimeImport();
			
			Application.IdleEvent += OnIdle;
		}
		
		public override void Dispose() {
			Application.IdleEvent -= OnIdle;
			BeforeRenderFrameEvent = null;
			RenderFrameEvent = null;
			AfterRenderFrameEvent = null;
			if( m_DeviceContext != null ) {
				m_DeviceContext.Dispose();
				m_DeviceContext = null;
			}
			base.Dispose();
		}
		
		public void SwapBuffers() {
			if( m_DeviceContext != null )
				m_DeviceContext.SwapBuffers();
		}
		
		#region Events
		
		protected override void OnClose() {
			Application.IdleEvent -= OnIdle;
			base.OnClose();
		}
		
		protected virtual void OnIdle() {
			if( m_DeviceContext != null && BeforeRenderFrameEvent != null ) BeforeRenderFrameEvent();
			if( m_DeviceContext != null && RenderFrameEvent != null ) RenderFrameEvent();
			SwapBuffers();
			if( m_DeviceContext != null && AfterRenderFrameEvent != null ) AfterRenderFrameEvent();
		}
	
		// TODO: Add DISPLAYCHANGE method capture

		protected override IntPtr WndProc(WindowMessageEnum uMsg, IntPtr wParam, IntPtr lParam) {
			switch(uMsg) {
				case WindowMessageEnum.SYSCOMMAND: {
					if( (int)wParam == 0xF140 // SC_SCREENSAVE
						|| (int)wParam == 0xF170 ) // SC_MONITORPOWER
						return IntPtr.Zero;
					break;
				}
			}
			return base.WndProc(uMsg, wParam, lParam);
		}

		#endregion
	}
}