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
		
		public static class Offset
        {
			public static readonly int m_vGlowColorRGBA        = (int)Marshal.OffsetOf(typeof(GlowObject), "m_vGlowColorRGBA");
			public static readonly int m_bRenderWhenOccluded   = (int)Marshal.OffsetOf(typeof(GlowObject), "m_bRenderWhenOccluded");
			public static readonly int m_bRenderWhenUnoccluded = (int)Marshal.OffsetOf(typeof(GlowObject), "m_bRenderWhenUnoccluded");
			public static readonly int m_nRenderStyle          = (int)Marshal.OffsetOf(typeof(GlowObject), "m_nRenderStyle");
		}
		
		[StructLayout(LayoutKind.Sequential, Pack = 0)]
		public unsafe struct GlowObject // Ignore error
        {
			IntPtr      m_pEntity;
            fixed float m_vGlowColorRGBA[4];
			byte        m_bGlowAlphaCappedByRenderAlpha;
			float       m_flGlowAlphaFunctionOfMaxVelocity;
			float       m_flGlowAlphaMax;
			float       m_flGlowPulseOverdrive;
			byte        m_bRenderWhenOccluded;
			byte        m_bRenderWhenUnoccluded;
			byte        m_bFullBloomRender;
			int         m_nFullBloomStencilTestValue;
			int         m_nRenderStyle;
			int         m_nSplitScreenSlot;
			int         m_nNextFreeSlot;
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

			for (int i = Offset.m_vGlowColorRGBA; i < 20; i++)
				Obj[i] = BytesColor[i / 4 - 1][i % 4];

			Obj[Offset.m_bRenderWhenOccluded] = 1;
			Obj[Offset.m_nRenderStyle] = 0;

			PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, GlowObjectBase, Obj, GlowObjectByteSize, IntPtr.Zero);
		}
    }
}
