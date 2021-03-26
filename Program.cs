using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgo_external_cs
{
    public static class Program
    {
        public static Forms.MainForm MainInstance = null;
        
        public static Hacks.HackBase[] HackInstances =
        {
            Hacks.Triggerbot.Instance,
            Hacks.EngineRadar.Instance,
            Hacks.EngineGlow.Instance,
            Hacks.ClantagChanger.Instance
        };

        public static void Log(string text)
        {
            if (MainInstance.rtbLog.InvokeRequired)
            {
                MainInstance.rtbLog.Invoke(new Action(() =>
                {
                    MainInstance.rtbLog.AppendText(text);
                    MainInstance.rtbLog.SelectionStart = MainInstance.rtbLog.Text.Length;
                    MainInstance.rtbLog.ScrollToCaret();
                }));
            }
            else
            {
                MainInstance.rtbLog.AppendText(text);
                MainInstance.rtbLog.SelectionStart = MainInstance.rtbLog.Text.Length;
                MainInstance.rtbLog.ScrollToCaret();
            }
        }

        public static string Status
        {
            set 
            {
                if (MainInstance.lblStatus.InvokeRequired)
                    MainInstance.lblStatus.Invoke(new Action(() => MainInstance.lblStatus.Text = value));
                else
                    MainInstance.lblStatus.Text = value;
            }
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainInstance = new Forms.MainForm());
        }
    }
}
