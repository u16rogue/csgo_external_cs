using System;
using csgo_external_cs.Extensions;

namespace csgo_external_cs.Utils
{
    public static class Pointers
    {
        public static IntPtr Traverse(IntPtr Address, params int[] Offsets)
        {
            if (Offsets.Length == 0)
                return Address;

            for (int OffsetIdx = 0; OffsetIdx < Offsets.Length; OffsetIdx++)
            {
                if (OffsetIdx == Offsets.Length - 1)
                    return Address + Offsets[OffsetIdx];

                byte[] NewAddress = new byte[4];
                if (!PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, Address + Offsets[OffsetIdx], NewAddress, 4, IntPtr.Zero))
                    return IntPtr.Zero;

                Address = NewAddress.ToIntPtr();
            }
            
            return IntPtr.Zero;
        }
    }
}
