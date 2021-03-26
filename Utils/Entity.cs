using System;
using csgo_external_cs.Extensions;

namespace csgo_external_cs.Utils
{
    public static class Entity
    {
        public static int GetHealth(IntPtr EntityBase)
        {
            byte[] Health = new byte[4];
            PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, EntityBase + CSGO.Offsets.m_iHealth,  Health, 4, IntPtr.Zero);
            return Health.ToInt32();
        }

        public static int GetTeam(IntPtr EntityBase)
        {
            byte[] Team = new byte[4];
            PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, EntityBase + CSGO.Offsets.m_iTeamNum, Team, 4, IntPtr.Zero);
            return Team.ToInt32();
        }

        public static bool IsDormant(IntPtr EntityBase)
        {
            byte[] Dormant = new byte[1];

            if (!PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, EntityBase + CSGO.Offsets.m_bDormant, Dormant, 1, IntPtr.Zero))
                return true;

            return Dormant[0] == 1;
        }

        public static int GetGlowIndex(IntPtr EntityBase)
        {
            byte[] GlowIndex = new byte[4];
            PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, EntityBase + CSGO.Offsets.m_iGlowIndex, GlowIndex, 4, IntPtr.Zero);
            return GlowIndex.ToInt32();
        }

        public static IntPtr GetLocalPlayer()
        {
            byte[] LocalPlayer = new byte[4];
            if (!PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, CSGO.Values.LocalPlayerPointer, LocalPlayer, 4, IntPtr.Zero))
                return IntPtr.Zero;

            return LocalPlayer.ToIntPtr();
        }

        public static IntPtr Get(int Index)
        {
            byte[] Entity = new byte[4];
            PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, CSGO.Values.dwEntityList + (Index * 0x10), Entity, 4, IntPtr.Zero);
            return Entity.ToIntPtr();
        }
    }
}
