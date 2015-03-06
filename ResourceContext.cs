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
using System.Runtime.InteropServices; // needed to import from dll

using IGE.Graphics;
using IGE.Graphics.OpenGL;
	
namespace IGE.Platform.Win32 {
	public sealed class ResourceContext : IResourceContext {

		private DeviceContext m_DC;
		private IntPtr m_hRC;
		
		public bool Disposed { get { return m_hRC == IntPtr.Zero; } }
	
		public ResourceContext(DeviceContext dc) {
			m_DC = dc;
			m_hRC = IntPtr.Zero;
			if( m_DC == null || m_DC.Disposed ) {
				GameDebugger.EngineLog(LogLevel.Error, "Device context cannot be used to create an OpenGL resource context");
				return;
			}
			m_hRC = WGL.CreateContext(m_DC.Handle);
			if( m_hRC != IntPtr.Zero )
				m_DC.BeforeReleaseEvent += OnBeforeDeviceContextRelease;
			else {
				// GameDebugger.EngineLog(LogLevel.Error, "Trying to create a resouce context returned a null handle. Error was: {0}", GL.GetError());
				GameDebugger.EngineLog(LogLevel.Error, "Trying to create a resouce context returned a null handle. Error was: {0}", IGE.Platform.Win32.API.Externals.GetLastError());
			}
				
		}
	
		public ResourceContext(ResourceContext rc) {
			m_DC = rc.m_DC;
			m_hRC = IntPtr.Zero;
			if( m_DC == null || m_DC.Disposed )
				return;
			m_hRC = WGL.CreateContext(m_DC.Handle);
			if( m_hRC != IntPtr.Zero ) {
				m_DC.BeforeReleaseEvent += OnBeforeDeviceContextRelease;
				WGL.ShareLists(rc.m_hRC, m_hRC);
			}
		}

		public bool Activate() {
			if( m_hRC != IntPtr.Zero && !m_DC.Disposed )
				return WGL.MakeCurrent(m_DC.Handle, m_hRC);
			return false;
		}
		
		public IResourceContext CreateSharedContext() {
			return new ResourceContext(this);
		}
		
		public void Dispose() {
			if( m_hRC != IntPtr.Zero ) {
				//GameDebugger.Log("Disposing Resource Context");
				if( WGL.GetCurrentContext() == m_hRC )
					GL.ResetContext();
				WGL.DeleteContext(m_hRC);
				m_hRC = IntPtr.Zero;
			}
			if( m_DC != null ) {
				m_DC.BeforeReleaseEvent -= OnBeforeDeviceContextRelease;
				m_DC = null;
			}			
		}

		private void OnBeforeDeviceContextRelease(DeviceContext dc) {
			if( m_hRC != IntPtr.Zero && dc == m_DC )
				Dispose();
		}
	}
}
