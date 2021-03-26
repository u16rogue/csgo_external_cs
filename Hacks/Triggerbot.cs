using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgo_external_cs.Hacks
{
    public class Triggerbot : HackBase
    {
        public static Triggerbot Instance = new Triggerbot();

        public Triggerbot()
        {
            Name = "Triggerbot";
        }

        public int Key = 0x12;
        public int Delta = 0;

        int NextAllowShot = 0;
        bool DidShoot = false;

        public override bool Initialize()
        {
            base.SetRunner(RunTriggerbot);
            base.ThreadHandle.Start();
            return true;
        }

        private void RunTriggerbot()
        {
            while (true)
            {
                if (!Program.MainInstance.cbTriggerbot.Checked)
                {
                    Thread.Sleep(500);
                    continue;
                }

                if (DidShoot)
                {
                    PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, CSGO.Values.dwForceAttack, new byte[] { 0x4 }, 1, IntPtr.Zero);
                    DidShoot = false;
                }

                if (PInvoke.user32.GetAsyncKeyState(Key) == 0)
                {
                    Thread.Sleep(1);
                    continue;
                }

                IntPtr LocalPlayer = Utils.Entity.GetLocalPlayer();

                if (LocalPlayer == IntPtr.Zero)
                {
                    Thread.Sleep(500);
                    continue;
                }
                
                byte[] ByteStore = new byte[1];
                if (!PInvoke.kernel32.ReadProcessMemory(CSGO.Handle, LocalPlayer + CSGO.Offsets.m_iCrosshairId, ByteStore, 1, IntPtr.Zero))
                    continue;

                if (ByteStore[0] == 0)
                    continue;

                if (Utils.Entity.GetHealth(Utils.Entity.Get(ByteStore[0] - 1)) < 1)
                    continue;

                if (Delta > 0)
                {
                    int CurrentTick = Environment.TickCount;

                    if (NextAllowShot == 0)
                    {
                        NextAllowShot = CurrentTick + Delta;
                        continue;
                    }

                    if (CurrentTick < NextAllowShot)
                        continue;

                    NextAllowShot = CurrentTick + Delta;

                    DidShoot = true;
                }

                ByteStore[0] = 5;
                PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, CSGO.Values.dwForceAttack, ByteStore, 1, IntPtr.Zero);

                if (Delta == 0)
                {
                    ByteStore[0] = 4;
                    PInvoke.kernel32.WriteProcessMemory(CSGO.Handle, CSGO.Values.dwForceAttack, ByteStore, 1, IntPtr.Zero);
                }
            }
        }
    }
}
