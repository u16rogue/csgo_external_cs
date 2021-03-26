using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csgo_external_cs.Hacks
{
    public class EngineRadar : HackBase
    {
        public static EngineRadar Instance = new EngineRadar();

        public EngineRadar()
        {
            Name = "Engine Radar";
        }

        public override bool Initialize()
        {
            base.SetRunner(RunEngineRadar);
            base.ThreadHandle.Start();
            return true;
        }

        private void RunEngineRadar()
        {
            while (true)
            {
                if (!Program.MainInstance.cbRadar.Checked)
                {
                    Thread.Sleep(500);
                    continue;
                }

                IntPtr LocalPlayer = Utils.Entity.GetLocalPlayer();
                int    LocalTeam   = Utils.Entity.GetTeam(LocalPlayer);
                for (int i = 1; i < 64; i++)
                {
                    IntPtr Entity = Utils.Entity.Get(i);
                    if (Entity == IntPtr.Zero || Entity == LocalPlayer || Utils.Entity.IsDormant(Entity) || Utils.Entity.GetTeam(Entity) == LocalTeam || Utils.Entity.GetHealth(Entity) < 1)
                        continue;

                    PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, Entity + CSGO.Offsets.m_bSpotted, new byte[] { 0x1 }, 1, IntPtr.Zero);
                }
            }
        }
    }
}
