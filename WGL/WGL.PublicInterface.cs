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

namespace IGE.Platform.Win32 {
	public static partial class WGL {
		public static IntPtr CreateContext(IntPtr hDC) { return Delegates.CreateContext(hDC); }
		public static IntPtr GetCurrentContext() { return Delegates.GetCurrentContext(); }
		public static bool MakeCurrent(IntPtr hDC, IntPtr hRC) { return Delegates.MakeCurrent(hDC, hRC) != 0; }
		public static bool ShareLists(IntPtr hRCShare, IntPtr hRCSource) { return Delegates.ShareLists(hRCShare, hRCSource) != 0; }
		public static bool DeleteContext(IntPtr hRC) { return Delegates.DeleteContext(hRC) != 0; }
		public static IntPtr GetProcAddress(string lpszProc) { return Delegates.GetProcAddress == null ? IntPtr.Zero : Delegates.GetProcAddress(lpszProc); }
		public static bool SwapInterval(int interval) { return Delegates.SwapIntervalEXT != null && Delegates.SwapIntervalEXT(interval) != 0; }
		public static int GetSwapInterval() { return (Delegates.GetSwapIntervalEXT != null) ? Delegates.GetSwapIntervalEXT() : 0; }
	}
}
