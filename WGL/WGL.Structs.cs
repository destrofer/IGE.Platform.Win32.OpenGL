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
using System.Runtime.InteropServices;

using IGE;

namespace IGE.Platform.Win32 {
	
    [StructLayout(LayoutKind.Sequential)]
    public struct LayerPlaneDescriptor {
        public static readonly ushort Size = (ushort)Marshal.SizeOf(typeof(LayerPlaneDescriptor)); 
        public ushort  Version; 
        public uint Flags; 
        public byte  PixelType; 
        public byte  ColorBits; 
        public byte  RedBits; 
        public byte  RedShift; 
        public byte  GreenBits; 
        public byte  GreenShift; 
        public byte  BlueBits; 
        public byte  BlueShift; 
        public byte  AlphaBits; 
        public byte  AlphaShift; 
        public byte  AccumBits; 
        public byte  AccumRedBits; 
        public byte  AccumGreenBits; 
        public byte  AccumBlueBits; 
        public byte  AccumAlphaBits; 
        public byte  DepthBits; 
        public byte  StencilBits; 
        public byte  AuxBuffers; 
        public byte  LayerPlane; 
        byte  Reserved; 
        public uint crTransparent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GlyphMetricsFloat {
        public float BlackBoxX;
        public float BlackBoxY;
        public Vector2 GlyphOrigin;
        public float CellIncX;
        public float CellIncY;
    }
}
