using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgo_external_cs.Forms
{
    public partial class AuthenticationForm : Form
    {
        bool Successful = false;

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        public bool Authenticate()
        {
            this.ShowDialog();
            return Successful;
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Successful = true;
            this.Close();
        }
    }
}
