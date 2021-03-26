using System;
using System.Runtime.InteropServices;
using csgo_external_cs.Extensions;

namespace csgo_external_cs.Utils
{
    public static class GlowObjectManager
    {
		public static readonly int END_OF_FREE_LIST = -1;
		public static readonly int ENTRY_IN_USE     = -2;
		public static readonly int GlowObjectByteSize = Marshal.SizeOf(typeof(GlowObject));

		// ps. offsets are wrong... will fix in the future!
		[StructLayout(LayoutKind.Sequential, Pack = 0)]
		public struct GlowObject
        {
			IntPtr m_pEntity; // 0
			float  m_vGlowColor_R; // 4
			float  m_vGlowColor_G; // 8
			float  m_vGlowColor_B; // 12
			float  m_flGlowAlpha; // 16
			byte   m_bGlowAlphaCappedByRenderAlpha; // 20
			float  m_flGlowAlphaFunctionOfMaxVelocity; // 21
			float  m_flGlowAlphaMax; // 25
			float  m_flGlowPulseOverdrive; // 29
			byte   m_bRenderWhenOccluded; // 33
			byte   m_bRenderWhenUnoccluded; // 34
			byte   m_bFullBloomRender; // 35
			int    m_nFullBloomStencilTestValue; // 36
			int    m_nRenderStyle; // 40
			int    m_nSplitScreenSlot; // 44
			int    m_nNextFreeSlot; // 48
		}

        public static IntPtr GetObject(int Index)
        {
			byte[] m_pMemory = new byte[4];
			PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, CSGO.Values.dwGlowObjectManager, m_pMemory, 4, IntPtr.Zero);
			return m_pMemory.ToIntPtr() + (Index * GlowObjectByteSize);
        }

		public static void ApplyGlow(IntPtr GlowObjectBase, float[] Color)
        {
			byte[] Obj = new byte[GlowObjectByteSize];
			PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, GlowObjectBase, Obj, GlowObjectByteSize, IntPtr.Zero);

			// very inefficient, will optimize later
			byte[][] BytesColor = new byte[][]
			{
				BitConverter.GetBytes(Color[0]),
				BitConverter.GetBytes(Color[1]),
				BitConverter.GetBytes(Color[2]),
				BitConverter.GetBytes(Color[3]),
			};

			for (int i = 4; i < 20; i++)
				Obj[i] = BytesColor[i / 4 - 1][i % 4];

			Obj[36] = 1;
			//Obj[37] = 1;
			Obj[44] = 0;

			PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, GlowObjectBase, Obj, GlowObjectByteSize, IntPtr.Zero);
		}
    }
}
