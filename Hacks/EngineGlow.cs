using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csgo_external_cs.Hacks
{
    public class EngineGlow : HackBase
    {
        public static EngineGlow Instance = new EngineGlow();

        public EngineGlow()
        {
            Name = "Engine Glow";
        }

        public override bool Initialize()
        {
            base.SetRunner(RunEngineGlow);
            base.ThreadHandle.Start();
            return true;
        }

        public bool GlowEnemy = false;
        public bool GlowTeam =  false;

        public int  GlowModeEnemy = 0;
        public bool GlowWhenDead = false;

        private void RunEngineGlow()
        {
            while (true)
            {
                if (!Program.MainInstance.cbGlowTeam.Checked && !Program.MainInstance.cbGlowEnemy.Checked)
                {
                    Thread.Sleep(500);
                    continue;
                }

                IntPtr LocalPlayer = Utils.Entity.GetLocalPlayer();
                int LocalTeam = Utils.Entity.GetTeam(LocalPlayer);
                bool PlayerAlive = Utils.Entity.GetHealth(LocalPlayer) > 0;

                for (int i = 1; i < 64; i++)
                {
                    IntPtr Entity = Utils.Entity.Get(i);
                    if (Entity == IntPtr.Zero || Entity == LocalPlayer || Utils.Entity.IsDormant(Entity))
                        continue;

                    int EntityHealth = Utils.Entity.GetHealth(Entity);
                    if (EntityHealth < 1)
                        continue;

                    int EntityTeam = Utils.Entity.GetTeam(Entity);

                    if (GlowEnemy && EntityTeam != LocalTeam)
                    {
                        if (GlowWhenDead && PlayerAlive)
                            continue;

                        Utils.GlowObjectManager.ApplyGlow(Utils.GlowObjectManager.GetObject(Utils.Entity.GetGlowIndex(Entity)), (GlowModeEnemy == 1 ? new float[] { 1, 0, 0, 1 } : new float[] { 1 - EntityHealth / 100, EntityHealth / 100, 0, 1 }));
                    }
                    else if (GlowTeam && EntityTeam == LocalTeam)
                    {
                        Utils.GlowObjectManager.ApplyGlow(Utils.GlowObjectManager.GetObject(Utils.Entity.GetGlowIndex(Entity)), new float[] { 0, 0, 1, 1 });
                    }
                }
            }
        }
    }
}
