using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgo_external_cs.Forms
{
    public partial class MainForm : Form
    {
        private Thread InitializeThread = null;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            cboxEnemyColor.SelectedIndex = 0;
            cboxTeamColor.SelectedIndex = 1;

            //if (!new Forms.AuthenticationForm().Authenticate())
            //{
            //    Application.Exit();
            //    return;
            //}

            InitializeThread = new Thread(CSGO.Initialize);
            InitializeThread.Start();
        }

        private void trbTriggerDelay_Scroll(object sender, EventArgs e)
        {
            Hacks.Triggerbot.Instance.Delta = trbTriggerDelay.Value;
            lblDelay.Text = trbTriggerDelay.Value.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (InitializeThread != null && InitializeThread.IsAlive)
                InitializeThread.Abort();

            foreach (Hacks.HackBase Hack in Program.HackInstances)
            {
                if (Hack.ThreadHandle != null && Hack.ThreadHandle.IsAlive)
                {
                    Program.Log("\nTerminating hack thread for " + Hack.Name);
                    Hack.ThreadHandle.Abort();
                }
            }

            if (CSGO.Handle != IntPtr.Zero)
            {
                Program.Log("\nClosing open handle...");
                PInvoke.kernel32.CloseHandle(CSGO.Handle);
            }
        }

        private void cbGlowEnemy_CheckedChanged(object sender, EventArgs e)
        {
            Hacks.EngineGlow.Instance.GlowEnemy = cbGlowEnemy.Checked;
        }

        private void cbGlowTeam_CheckedChanged(object sender, EventArgs e)
        {
            Hacks.EngineGlow.Instance.GlowTeam = cbGlowTeam.Checked;
        }

        private void cbVisualsDead_CheckedChanged(object sender, EventArgs e)
        {
            Hacks.EngineGlow.Instance.GlowWhenDead = cbVisualsDead.Checked;
        }

        private void cboxEnemyColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hacks.EngineGlow.Instance.GlowModeEnemy = cboxEnemyColor.SelectedIndex;
        }

        private void cboxTeamColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hacks.EngineGlow.Instance.GlowModeTeam = cboxTeamColor.SelectedIndex;
        }
    }
}
