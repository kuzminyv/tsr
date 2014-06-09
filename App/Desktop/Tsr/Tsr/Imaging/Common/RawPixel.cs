using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    [StructLayout(LayoutKind.Explicit)]
    public struct RawPixel
    {
        // 32 bit BGRA 
        [FieldOffset(0)]
        public UInt32 BGRA;
        // 8 bit components
        [FieldOffset(0)]
        public byte B;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(2)]
        public byte R;
        [FieldOffset(3)]
        public byte A;
    }
}
