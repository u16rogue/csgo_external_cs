using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_external_cs.Extensions
{
    public static class ByteExtension
    {
        public static int ToInt32(this byte[] inst)
        {
            return BitConverter.ToInt32(inst, 0);
        }

        public static IntPtr ToIntPtr(this byte[] inst)
        {
            return (IntPtr)BitConverter.ToInt32(inst, 0);
        }
    }
}
