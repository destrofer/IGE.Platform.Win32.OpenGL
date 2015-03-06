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

namespace IGE.Platform.Win32 {
	public static partial class WGL {
		public partial class Delegates {
			// GetProcAddress MUST be first to be imported
			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetProcAddress(String lpszProc);
			public static wglGetProcAddress GetProcAddress;
			
			[RuntimeImport("opengl32", true)]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglCreateContext(IntPtr hDc);
			public static wglCreateContext CreateContext;

			[RuntimeImport("opengl32", true)]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglDeleteContext(IntPtr oldContext);
			public static wglDeleteContext DeleteContext;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetCurrentContext();
			public static wglGetCurrentContext GetCurrentContext;

			[RuntimeImport("opengl32", true)]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglMakeCurrent(IntPtr hDc, IntPtr newContext);
			public static wglMakeCurrent MakeCurrent;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglCopyContext(IntPtr hglrcSrc, IntPtr hglrcDst, UInt32 mask);
			public static wglCopyContext CopyContext;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglChoosePixelFormat(IntPtr hDc, PixelFormatDescriptor* pPfd);
			public unsafe static wglChoosePixelFormat ChoosePixelFormat;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglDescribePixelFormat(IntPtr hdc, int ipfd, UInt32 cjpfd, PixelFormatDescriptor* ppfd);
			public unsafe static wglDescribePixelFormat DescribePixelFormat;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetCurrentDC();
			public static wglGetCurrentDC GetCurrentDC;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetDefaultProcAddress(String lpszProc);
			public static wglGetDefaultProcAddress GetDefaultProcAddress;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGetPixelFormat(IntPtr hdc);
			public static wglGetPixelFormat GetPixelFormat;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetPixelFormat(IntPtr hdc, int ipfd, PixelFormatDescriptor* ppfd);
			public unsafe static wglSetPixelFormat SetPixelFormat;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglSwapBuffers(IntPtr hdc);
			public static wglSwapBuffers SwapBuffers;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglShareLists(IntPtr hrcSrvShare, IntPtr hrcSrvSource);
			public static wglShareLists ShareLists;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglCreateLayerContext(IntPtr hDc, int level);
			public static wglCreateLayerContext CreateLayerContext;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglDescribeLayerPlane(IntPtr hDc, int pixelFormat, int layerPlane, UInt32 nBytes, LayerPlaneDescriptor* plpd);
			public unsafe static wglDescribeLayerPlane DescribeLayerPlane;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, Int32* pcr);
			public unsafe static wglSetLayerPaletteEntries SetLayerPaletteEntries;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetLayerPaletteEntries(IntPtr hdc, int iLayerPlane, int iStart, int cEntries, Int32* pcr);
			public unsafe static wglGetLayerPaletteEntries GetLayerPaletteEntries;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglRealizeLayerPalette(IntPtr hdc, int iLayerPlane, int bRealize);
			public static wglRealizeLayerPalette RealizeLayerPalette;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglSwapLayerBuffers(IntPtr hdc, UInt32 fuFlags);
			public static wglSwapLayerBuffers SwapLayerBuffers;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglUseFontBitmapsA(IntPtr hDC, Int32 first, Int32 count, Int32 listBase);
			public static wglUseFontBitmapsA UseFontBitmapsA;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglUseFontBitmapsW(IntPtr hDC, Int32 first, Int32 count, Int32 listBase);
			public static wglUseFontBitmapsW UseFontBitmapsW;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglUseFontOutlinesA(IntPtr hDC, Int32 first, Int32 count, Int32 listBase, float thickness, float deviation, Int32 fontMode, GlyphMetricsFloat* glyphMetrics);
			public unsafe static wglUseFontOutlinesA UseFontOutlinesA;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglUseFontOutlinesW(IntPtr hDC, Int32 first, Int32 count, Int32 listBase, float thickness, float deviation, Int32 fontMode, GlyphMetricsFloat* glyphMetrics);
			public unsafe static wglUseFontOutlinesW UseFontOutlinesW;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate IntPtr wglCreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, int* attribList);
			public unsafe static wglCreateContextAttribsARB CreateContextAttribsARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglCreateBufferRegionARB(IntPtr hDC, int iLayerPlane, UInt32 uType);
			public static wglCreateBufferRegionARB CreateBufferRegionARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate void wglDeleteBufferRegionARB(IntPtr hRegion);
			public static wglDeleteBufferRegionARB DeleteBufferRegionARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglSaveBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height);
			public static wglSaveBufferRegionARB SaveBufferRegionARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglRestoreBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc);
			public static wglRestoreBufferRegionARB RestoreBufferRegionARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetExtensionsStringARB(IntPtr hdc);
			public static wglGetExtensionsStringARB GetExtensionsStringARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, UInt32 nAttributes, int* piAttributes, [Out] int* piValues);
			public unsafe static wglGetPixelFormatAttribivARB GetPixelFormatAttribivARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetPixelFormatAttribfvARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, UInt32 nAttributes, int* piAttributes, [Out] Single* pfValues);
			public unsafe static wglGetPixelFormatAttribfvARB GetPixelFormatAttribfvARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglChoosePixelFormatARB(IntPtr hdc, int* piAttribIList, Single* pfAttribFList, UInt32 nMaxFormats, [Out] int* piFormats, [Out] UInt32* nNumFormats);
			public unsafe static wglChoosePixelFormatARB ChoosePixelFormatARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglMakeContextCurrentARB(IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc);
			public static wglMakeContextCurrentARB MakeContextCurrentARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetCurrentReadDCARB();
			public static wglGetCurrentReadDCARB GetCurrentReadDCARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate IntPtr wglCreatePbufferARB(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList);
			public unsafe static wglCreatePbufferARB CreatePbufferARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetPbufferDCARB(IntPtr hPbuffer);
			public static wglGetPbufferDCARB GetPbufferDCARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglReleasePbufferDCARB(IntPtr hPbuffer, IntPtr hDC);
			public static wglReleasePbufferDCARB ReleasePbufferDCARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglDestroyPbufferARB(IntPtr hPbuffer);
			public static wglDestroyPbufferARB DestroyPbufferARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglQueryPbufferARB(IntPtr hPbuffer, int iAttribute, [Out] int* piValue);
			public unsafe static wglQueryPbufferARB QueryPbufferARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglBindTexImageARB(IntPtr hPbuffer, int iBuffer);
			public static wglBindTexImageARB BindTexImageARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglReleaseTexImageARB(IntPtr hPbuffer, int iBuffer);
			public static wglReleaseTexImageARB ReleaseTexImageARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetPbufferAttribARB(IntPtr hPbuffer, int* piAttribList);
			public unsafe static wglSetPbufferAttribARB SetPbufferAttribARB;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate bool wglCreateDisplayColorTableEXT(UInt16 id);
			public static wglCreateDisplayColorTableEXT CreateDisplayColorTableEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate bool wglLoadDisplayColorTableEXT(UInt16* table, UInt32 length);
			public unsafe static wglLoadDisplayColorTableEXT LoadDisplayColorTableEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate bool wglBindDisplayColorTableEXT(UInt16 id);
			public static wglBindDisplayColorTableEXT BindDisplayColorTableEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate void wglDestroyDisplayColorTableEXT(UInt16 id);
			public static wglDestroyDisplayColorTableEXT DestroyDisplayColorTableEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetExtensionsStringEXT();
			public static wglGetExtensionsStringEXT GetExtensionsStringEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglMakeContextCurrentEXT(IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc);
			public static wglMakeContextCurrentEXT MakeContextCurrentEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetCurrentReadDCEXT();
			public static wglGetCurrentReadDCEXT GetCurrentReadDCEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate IntPtr wglCreatePbufferEXT(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList);
			public unsafe static wglCreatePbufferEXT CreatePbufferEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate IntPtr wglGetPbufferDCEXT(IntPtr hPbuffer);
			public static wglGetPbufferDCEXT GetPbufferDCEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglReleasePbufferDCEXT(IntPtr hPbuffer, IntPtr hDC);
			public static wglReleasePbufferDCEXT ReleasePbufferDCEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglDestroyPbufferEXT(IntPtr hPbuffer);
			public static wglDestroyPbufferEXT DestroyPbufferEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglQueryPbufferEXT(IntPtr hPbuffer, int iAttribute, [Out] int* piValue);
			public unsafe static wglQueryPbufferEXT QueryPbufferEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetPixelFormatAttribivEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, UInt32 nAttributes, [Out] int* piAttributes, [Out] int* piValues);
			public unsafe static wglGetPixelFormatAttribivEXT GetPixelFormatAttribivEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetPixelFormatAttribfvEXT(IntPtr hdc, int iPixelFormat, int iLayerPlane, UInt32 nAttributes, [Out] int* piAttributes, [Out] Single* pfValues);
			public unsafe static wglGetPixelFormatAttribfvEXT GetPixelFormatAttribfvEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglChoosePixelFormatEXT(IntPtr hdc, int* piAttribIList, Single* pfAttribFList, UInt32 nMaxFormats, [Out] int* piFormats, [Out] UInt32* nNumFormats);
			public unsafe static wglChoosePixelFormatEXT ChoosePixelFormatEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglSwapIntervalEXT(int interval);
			public static wglSwapIntervalEXT SwapIntervalEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGetSwapIntervalEXT();
			public static wglGetSwapIntervalEXT GetSwapIntervalEXT;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate IntPtr wglAllocateMemoryNV(Int32 size, Single readfreq, Single writefreq, Single priority);
			public unsafe static wglAllocateMemoryNV AllocateMemoryNV;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate void wglFreeMemoryNV([Out] IntPtr pointer);
			public static wglFreeMemoryNV FreeMemoryNV;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetSyncValuesOML(IntPtr hdc, [Out] Int64* ust, [Out] Int64* msc, [Out] Int64* sbc);
			public unsafe static wglGetSyncValuesOML GetSyncValuesOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetMscRateOML(IntPtr hdc, [Out] Int32* numerator, [Out] Int32* denominator);
			public unsafe static wglGetMscRateOML GetMscRateOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate Int64 wglSwapBuffersMscOML(IntPtr hdc, Int64 target_msc, Int64 divisor, Int64 remainder);
			public static wglSwapBuffersMscOML SwapBuffersMscOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate Int64 wglSwapLayerBuffersMscOML(IntPtr hdc, int fuPlanes, Int64 target_msc, Int64 divisor, Int64 remainder);
			public static wglSwapLayerBuffersMscOML SwapLayerBuffersMscOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglWaitForMscOML(IntPtr hdc, Int64 target_msc, Int64 divisor, Int64 remainder, [Out] Int64* ust, [Out] Int64* msc, [Out] Int64* sbc);
			public unsafe static wglWaitForMscOML WaitForMscOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglWaitForSbcOML(IntPtr hdc, Int64 target_sbc, [Out] Int64* ust, [Out] Int64* msc, [Out] Int64* sbc);
			public unsafe static wglWaitForSbcOML WaitForSbcOML;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetDigitalVideoParametersI3D(IntPtr hDC, int iAttribute, [Out] int* piValue);
			public unsafe static wglGetDigitalVideoParametersI3D GetDigitalVideoParametersI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetDigitalVideoParametersI3D(IntPtr hDC, int iAttribute, int* piValue);
			public unsafe static wglSetDigitalVideoParametersI3D SetDigitalVideoParametersI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGammaTableParametersI3D(IntPtr hDC, int iAttribute, [Out] int* piValue);
			public unsafe static wglGetGammaTableParametersI3D GetGammaTableParametersI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetGammaTableParametersI3D(IntPtr hDC, int iAttribute, int* piValue);
			public unsafe static wglSetGammaTableParametersI3D SetGammaTableParametersI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGammaTableI3D(IntPtr hDC, int iEntries, [Out] UInt16* puRed, [Out] UInt16* puGreen, [Out] UInt16* puBlue);
			public unsafe static wglGetGammaTableI3D GetGammaTableI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglSetGammaTableI3D(IntPtr hDC, int iEntries, UInt16* puRed, UInt16* puGreen, UInt16* puBlue);
			public unsafe static wglSetGammaTableI3D SetGammaTableI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglEnableGenlockI3D(IntPtr hDC);
			public static wglEnableGenlockI3D EnableGenlockI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglDisableGenlockI3D(IntPtr hDC);
			public static wglDisableGenlockI3D DisableGenlockI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglIsEnabledGenlockI3D(IntPtr hDC, [Out] int* pFlag);
			public unsafe static wglIsEnabledGenlockI3D IsEnabledGenlockI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGenlockSourceI3D(IntPtr hDC, UInt32 uSource);
			public static wglGenlockSourceI3D GenlockSourceI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGenlockSourceI3D(IntPtr hDC, [Out] UInt32* uSource);
			public unsafe static wglGetGenlockSourceI3D GetGenlockSourceI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGenlockSourceEdgeI3D(IntPtr hDC, UInt32 uEdge);
			public static wglGenlockSourceEdgeI3D GenlockSourceEdgeI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGenlockSourceEdgeI3D(IntPtr hDC, [Out] UInt32* uEdge);
			public unsafe static wglGetGenlockSourceEdgeI3D GetGenlockSourceEdgeI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGenlockSampleRateI3D(IntPtr hDC, UInt32 uRate);
			public static wglGenlockSampleRateI3D GenlockSampleRateI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGenlockSampleRateI3D(IntPtr hDC, [Out] UInt32* uRate);
			public unsafe static wglGetGenlockSampleRateI3D GetGenlockSampleRateI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglGenlockSourceDelayI3D(IntPtr hDC, UInt32 uDelay);
			public static wglGenlockSourceDelayI3D GenlockSourceDelayI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglGetGenlockSourceDelayI3D(IntPtr hDC, [Out] UInt32* uDelay);
			public unsafe static wglGetGenlockSourceDelayI3D GetGenlockSourceDelayI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate int wglQueryGenlockMaxSourceDelayI3D(IntPtr hDC, [Out] UInt32* uMaxLineDelay, [Out] UInt32* uMaxPixelDelay);
			public unsafe static wglQueryGenlockMaxSourceDelayI3D QueryGenlockMaxSourceDelayI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public unsafe delegate IntPtr wglCreateImageBufferI3D(IntPtr hDC, Int32 dwSize, UInt32 uFlags);
			public unsafe static wglCreateImageBufferI3D CreateImageBufferI3D;

			[RuntimeImport("opengl32")]
			[System.Security.SuppressUnmanagedCodeSecurity()]
			public delegate int wglDestroyImageBufferI3D(IntPtr hDC, IntPtr pAddress);
			public static wglDestroyImageBufferI3D DestroyImageBufferI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public unsafe delegate int wglAssociateImageBufferEventsI3D(IntPtr hDC, IntPtr* pEvent, IntPtr pAddress, Int32* pSize, UInt32 count);
            public unsafe static wglAssociateImageBufferEventsI3D AssociateImageBufferEventsI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public delegate int wglReleaseImageBufferEventsI3D(IntPtr hDC, IntPtr pAddress, UInt32 count);
            public static wglReleaseImageBufferEventsI3D ReleaseImageBufferEventsI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public delegate int wglEnableFrameLockI3D();
            public static wglEnableFrameLockI3D EnableFrameLockI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public delegate int wglDisableFrameLockI3D();
            public static wglDisableFrameLockI3D DisableFrameLockI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public unsafe delegate int wglIsEnabledFrameLockI3D([Out] int* pFlag);
            public unsafe static wglIsEnabledFrameLockI3D IsEnabledFrameLockI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public unsafe delegate int wglQueryFrameLockMasterI3D([Out] int* pFlag);
            public unsafe static wglQueryFrameLockMasterI3D QueryFrameLockMasterI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public unsafe delegate int wglGetFrameUsageI3D([Out] float* pUsage);
            public unsafe static wglGetFrameUsageI3D GetFrameUsageI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public delegate int wglBeginFrameTrackingI3D();
            public static wglBeginFrameTrackingI3D BeginFrameTrackingI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public delegate int wglEndFrameTrackingI3D();
            public static wglEndFrameTrackingI3D EndFrameTrackingI3D;
            
			[RuntimeImport("opengl32")]
            [System.Security.SuppressUnmanagedCodeSecurity()]
            public unsafe delegate int wglQueryFrameTrackingI3D([Out] Int32* pFrameCount, [Out] Int32* pMissedFrames, [Out] float* pLastMissedUsage);
            public unsafe static wglQueryFrameTrackingI3D QueryFrameTrackingI3D;
		}
	}
}
