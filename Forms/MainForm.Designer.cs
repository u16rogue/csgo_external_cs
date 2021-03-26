
namespace csgo_external_cs.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTriggerbot = new System.Windows.Forms.GroupBox();
            this.btnSetKey = new System.Windows.Forms.Button();
            this.cbTriggerOnKey = new System.Windows.Forms.CheckBox();
            this.cbTriggerFriendlyFire = new System.Windows.Forms.CheckBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trbTriggerDelay = new System.Windows.Forms.TrackBar();
            this.cbTriggerbot = new System.Windows.Forms.CheckBox();
            this.gbESP = new System.Windows.Forms.GroupBox();
            this.cbRadar = new System.Windows.Forms.CheckBox();
            this.cbVisualsDead = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbMiscClantag = new System.Windows.Forms.GroupBox();
            this.btnSetClantag = new System.Windows.Forms.Button();
            this.tbClantag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbGlow = new System.Windows.Forms.GroupBox();
            this.cboxTeamColor = new System.Windows.Forms.ComboBox();
            this.cboxEnemyColor = new System.Windows.Forms.ComboBox();
            this.cbGlowTeam = new System.Windows.Forms.CheckBox();
            this.cbGlowEnemy = new System.Windows.Forms.CheckBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.gbTriggerbot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTriggerDelay)).BeginInit();
            this.gbESP.SuspendLayout();
            this.gbMiscClantag.SuspendLayout();
            this.gbGlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTriggerbot
            // 
            this.gbTriggerbot.Controls.Add(this.btnSetKey);
            this.gbTriggerbot.Controls.Add(this.cbTriggerOnKey);
            this.gbTriggerbot.Controls.Add(this.cbTriggerFriendlyFire);
            this.gbTriggerbot.Controls.Add(this.lblDelay);
            this.gbTriggerbot.Controls.Add(this.label1);
            this.gbTriggerbot.Controls.Add(this.trbTriggerDelay);
            this.gbTriggerbot.Controls.Add(this.cbTriggerbot);
            this.gbTriggerbot.ForeColor = System.Drawing.Color.White;
            this.gbTriggerbot.Location = new System.Drawing.Point(12, 12);
            this.gbTriggerbot.Name = "gbTriggerbot";
            this.gbTriggerbot.Size = new System.Drawing.Size(343, 105);
            this.gbTriggerbot.TabIndex = 0;
            this.gbTriggerbot.TabStop = false;
            this.gbTriggerbot.Text = "[Combat] Triggerbot";
            // 
            // btnSetKey
            // 
            this.btnSetKey.Enabled = false;
            this.btnSetKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetKey.Location = new System.Drawing.Point(256, 73);
            this.btnSetKey.Name = "btnSetKey";
            this.btnSetKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetKey.TabIndex = 7;
            this.btnSetKey.Text = "<key>";
            this.btnSetKey.UseVisualStyleBackColor = true;
            // 
            // cbTriggerOnKey
            // 
            this.cbTriggerOnKey.AutoSize = true;
            this.cbTriggerOnKey.Enabled = false;
            this.cbTriggerOnKey.Location = new System.Drawing.Point(188, 77);
            this.cbTriggerOnKey.Name = "cbTriggerOnKey";
            this.cbTriggerOnKey.Size = new System.Drawing.Size(62, 17);
            this.cbTriggerOnKey.TabIndex = 6;
            this.cbTriggerOnKey.Text = "On key";
            this.cbTriggerOnKey.UseVisualStyleBackColor = true;
            // 
            // cbTriggerFriendlyFire
            // 
            this.cbTriggerFriendlyFire.AutoSize = true;
            this.cbTriggerFriendlyFire.Enabled = false;
            this.cbTriggerFriendlyFire.Location = new System.Drawing.Point(6, 77);
            this.cbTriggerFriendlyFire.Name = "cbTriggerFriendlyFire";
            this.cbTriggerFriendlyFire.Size = new System.Drawing.Size(104, 17);
            this.cbTriggerFriendlyFire.TabIndex = 5;
            this.cbTriggerFriendlyFire.Text = "Friendly fire";
            this.cbTriggerFriendlyFire.UseVisualStyleBackColor = true;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(286, 52);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(13, 13);
            this.lblDelay.TabIndex = 4;
            this.lblDelay.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Delay:";
            // 
            // trbTriggerDelay
            // 
            this.trbTriggerDelay.Location = new System.Drawing.Point(48, 49);
            this.trbTriggerDelay.Maximum = 200;
            this.trbTriggerDelay.Name = "trbTriggerDelay";
            this.trbTriggerDelay.Size = new System.Drawing.Size(232, 45);
            this.trbTriggerDelay.TabIndex = 2;
            this.trbTriggerDelay.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbTriggerDelay.Scroll += new System.EventHandler(this.trbTriggerDelay_Scroll);
            // 
            // cbTriggerbot
            // 
            this.cbTriggerbot.AutoSize = true;
            this.cbTriggerbot.Location = new System.Drawing.Point(6, 19);
            this.cbTriggerbot.Name = "cbTriggerbot";
            this.cbTriggerbot.Size = new System.Drawing.Size(68, 17);
            this.cbTriggerbot.TabIndex = 2;
            this.cbTriggerbot.Text = "Enabled";
            this.cbTriggerbot.UseVisualStyleBackColor = true;
            // 
            // gbESP
            // 
            this.gbESP.Controls.Add(this.cbRadar);
            this.gbESP.ForeColor = System.Drawing.Color.White;
            this.gbESP.Location = new System.Drawing.Point(12, 123);
            this.gbESP.Name = "gbESP";
            this.gbESP.Size = new System.Drawing.Size(343, 45);
            this.gbESP.TabIndex = 1;
            this.gbESP.TabStop = false;
            this.gbESP.Text = "[Visuals] ESP";
            // 
            // cbRadar
            // 
            this.cbRadar.AutoSize = true;
            this.cbRadar.Location = new System.Drawing.Point(6, 19);
            this.cbRadar.Name = "cbRadar";
            this.cbRadar.Size = new System.Drawing.Size(98, 17);
            this.cbRadar.TabIndex = 6;
            this.cbRadar.Text = "Engine Radar";
            this.cbRadar.UseVisualStyleBackColor = true;
            // 
            // cbVisualsDead
            // 
            this.cbVisualsDead.AutoSize = true;
            this.cbVisualsDead.Location = new System.Drawing.Point(85, 362);
            this.cbVisualsDead.Name = "cbVisualsDead";
            this.cbVisualsDead.Size = new System.Drawing.Size(200, 17);
            this.cbVisualsDead.TabIndex = 11;
            this.cbVisualsDead.Text = "Only enable visuals when dead";
            this.cbVisualsDead.UseVisualStyleBackColor = true;
            this.cbVisualsDead.CheckedChanged += new System.EventHandler(this.cbVisualsDead_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 381);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Idle...";
            // 
            // gbMiscClantag
            // 
            this.gbMiscClantag.Controls.Add(this.btnSetClantag);
            this.gbMiscClantag.Controls.Add(this.tbClantag);
            this.gbMiscClantag.Controls.Add(this.label2);
            this.gbMiscClantag.Enabled = false;
            this.gbMiscClantag.ForeColor = System.Drawing.Color.White;
            this.gbMiscClantag.Location = new System.Drawing.Point(12, 302);
            this.gbMiscClantag.Name = "gbMiscClantag";
            this.gbMiscClantag.Size = new System.Drawing.Size(343, 51);
            this.gbMiscClantag.TabIndex = 3;
            this.gbMiscClantag.TabStop = false;
            this.gbMiscClantag.Text = "[Misc] Clantag Changer";
            // 
            // btnSetClantag
            // 
            this.btnSetClantag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetClantag.Location = new System.Drawing.Point(262, 16);
            this.btnSetClantag.Name = "btnSetClantag";
            this.btnSetClantag.Size = new System.Drawing.Size(75, 23);
            this.btnSetClantag.TabIndex = 8;
            this.btnSetClantag.Text = "Set";
            this.btnSetClantag.UseVisualStyleBackColor = true;
            // 
            // tbClantag
            // 
            this.tbClantag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tbClantag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClantag.ForeColor = System.Drawing.Color.White;
            this.tbClantag.Location = new System.Drawing.Point(61, 19);
            this.tbClantag.MaxLength = 16;
            this.tbClantag.Name = "tbClantag";
            this.tbClantag.Size = new System.Drawing.Size(195, 20);
            this.tbClantag.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clantag:";
            // 
            // gbGlow
            // 
            this.gbGlow.Controls.Add(this.cboxTeamColor);
            this.gbGlow.Controls.Add(this.cboxEnemyColor);
            this.gbGlow.Controls.Add(this.cbGlowTeam);
            this.gbGlow.Controls.Add(this.cbGlowEnemy);
            this.gbGlow.ForeColor = System.Drawing.Color.White;
            this.gbGlow.Location = new System.Drawing.Point(12, 174);
            this.gbGlow.Name = "gbGlow";
            this.gbGlow.Size = new System.Drawing.Size(343, 122);
            this.gbGlow.TabIndex = 4;
            this.gbGlow.TabStop = false;
            this.gbGlow.Text = "[Visuals] Glow ESP";
            // 
            // cboxTeamColor
            // 
            this.cboxTeamColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboxTeamColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTeamColor.ForeColor = System.Drawing.Color.White;
            this.cboxTeamColor.FormattingEnabled = true;
            this.cboxTeamColor.Items.AddRange(new object[] {
            "Player Health",
            "Static Blue"});
            this.cboxTeamColor.Location = new System.Drawing.Point(25, 92);
            this.cboxTeamColor.Name = "cboxTeamColor";
            this.cboxTeamColor.Size = new System.Drawing.Size(312, 21);
            this.cboxTeamColor.TabIndex = 14;
            // 
            // cboxEnemyColor
            // 
            this.cboxEnemyColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboxEnemyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEnemyColor.ForeColor = System.Drawing.Color.White;
            this.cboxEnemyColor.FormattingEnabled = true;
            this.cboxEnemyColor.Items.AddRange(new object[] {
            "Player Health",
            "Static Red"});
            this.cboxEnemyColor.Location = new System.Drawing.Point(25, 42);
            this.cboxEnemyColor.Name = "cboxEnemyColor";
            this.cboxEnemyColor.Size = new System.Drawing.Size(312, 21);
            this.cboxEnemyColor.TabIndex = 13;
            this.cboxEnemyColor.SelectedIndexChanged += new System.EventHandler(this.cboxEnemyColor_SelectedIndexChanged);
            // 
            // cbGlowTeam
            // 
            this.cbGlowTeam.AutoSize = true;
            this.cbGlowTeam.Location = new System.Drawing.Point(6, 69);
            this.cbGlowTeam.Name = "cbGlowTeam";
            this.cbGlowTeam.Size = new System.Drawing.Size(122, 17);
            this.cbGlowTeam.TabIndex = 12;
            this.cbGlowTeam.Text = "Team Engine Glow";
            this.cbGlowTeam.UseVisualStyleBackColor = true;
            this.cbGlowTeam.CheckedChanged += new System.EventHandler(this.cbGlowTeam_CheckedChanged);
            // 
            // cbGlowEnemy
            // 
            this.cbGlowEnemy.AutoSize = true;
            this.cbGlowEnemy.Location = new System.Drawing.Point(6, 19);
            this.cbGlowEnemy.Name = "cbGlowEnemy";
            this.cbGlowEnemy.Size = new System.Drawing.Size(128, 17);
            this.cbGlowEnemy.TabIndex = 11;
            this.cbGlowEnemy.Text = "Enemy Engine Glow";
            this.cbGlowEnemy.UseVisualStyleBackColor = true;
            this.cbGlowEnemy.CheckedChanged += new System.EventHandler(this.cbGlowEnemy_CheckedChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(361, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(399, 382);
            this.rtbLog.TabIndex = 12;
            this.rtbLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(772, 403);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.cbVisualsDead);
            this.Controls.Add(this.gbGlow);
            this.Controls.Add(this.gbMiscClantag);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbTriggerbot);
            this.Controls.Add(this.gbESP);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbTriggerbot.ResumeLayout(false);
            this.gbTriggerbot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTriggerDelay)).EndInit();
            this.gbESP.ResumeLayout(false);
            this.gbESP.PerformLayout();
            this.gbMiscClantag.ResumeLayout(false);
            this.gbMiscClantag.PerformLayout();
            this.gbGlow.ResumeLayout(false);
            this.gbGlow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbESP;
        private System.Windows.Forms.Button btnSetKey;
        private System.Windows.Forms.GroupBox gbMiscClantag;
        private System.Windows.Forms.Button btnSetClantag;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gbGlow;
        public System.Windows.Forms.GroupBox gbTriggerbot;
        public System.Windows.Forms.TrackBar trbTriggerDelay;
        public System.Windows.Forms.CheckBox cbTriggerbot;
        public System.Windows.Forms.CheckBox cbTriggerFriendlyFire;
        public System.Windows.Forms.CheckBox cbRadar;
        public System.Windows.Forms.CheckBox cbVisualsDead;
        public System.Windows.Forms.CheckBox cbTriggerOnKey;
        public System.Windows.Forms.TextBox tbClantag;
        public System.Windows.Forms.ComboBox cboxTeamColor;
        public System.Windows.Forms.ComboBox cboxEnemyColor;
        public System.Windows.Forms.CheckBox cbGlowTeam;
        public System.Windows.Forms.CheckBox cbGlowEnemy;
        public System.Windows.Forms.RichTextBox rtbLog;
    }
}

