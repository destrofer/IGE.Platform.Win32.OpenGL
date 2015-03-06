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
using System.Reflection;
using System.Collections.Generic;

using IGE.Graphics;

namespace IGE.Platform.Win32 {
	/// <summary>
	/// </summary>
	public sealed class OpenGL : IGraphicsDriver {
		public string DriverName { get { return "OpenGL"; } }
		public Version DriverVersion { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
		public bool IsSupported { get { return true; } }

		internal static OpenGL Instance = null;
		public static OpenGL GetInstance() {
			if( Instance != null )
				return Instance;
			return Instance = new OpenGL();
		}

		private OpenGL() {
		}
		
		public bool Initialize() {
			return true;
		}
		
		public bool Test() {
			return true;
		}
		
		public IntPtr GetGLProcAddress(string funcName) {
			WGL.EnsureLoaded();
			return WGL.GetProcAddress(funcName);
		}
		
		public void ResetContext() {
			WGL.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
		}

		public IOpenGLWindow CreateWindow(INativeWindow parent, int x, int y, int width, int height) {
			return new OpenGLWindow(parent, x, y, width, height);
		}
	}
}