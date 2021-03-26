using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_external_cs.Classes
{
    public class CSGOModule
    {
        public CSGOModule(string Name_)
        {
            Name = Name_;
            Instances.Add(Name_, this);
        }

        public IntPtr PatternScan(byte[] bytes, string mask, int extra = 0x0, bool GetValueOnMatch = false)
        {
            if (bytes.Length != mask.Length)
                return IntPtr.Zero;

            if (CachedModule == null)
            {
                CachedModule = new byte[Size];
                if (!PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, BaseAddress, CachedModule, Size, IntPtr.Zero))
                {
                    return IntPtr.Zero;
                }
            }

            for (int rva = 0; rva < Size; rva++)
            {
                for (int idx = 0; idx < bytes.Length; idx++)
                {
                    if (mask[idx] == '?')
                        continue;

                    if (mask[idx] != 'x' || CachedModule[rva + idx] != bytes[idx])
                        break;

                    if (idx == mask.Length - 1)
                    {
                        if (GetValueOnMatch)
                        {
                            return (IntPtr)BitConverter.ToUInt32(CachedModule, rva + extra);
                        }
                        else
                        {
                            return BaseAddress + rva + extra;
                        }
                    }
                }
            }

            return IntPtr.Zero;
        }

        public void ClearCache()
        {
            CachedModule = null;
        }

        public string Name         = "";
        public IntPtr BaseAddress = IntPtr.Zero;
        public int    Size         = 0;

        private byte[] CachedModule = null;

        public static Dictionary<string, CSGOModule> Instances = new Dictionary<string, CSGOModule>() { };
    }
}
