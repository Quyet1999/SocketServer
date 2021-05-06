using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class LockScreen : Form
    {
        public LockScreen()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txbUsername.Text == "1")
            {
                this.Close();
            }
        }
        int tries;
        bool approveClose;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch ((keyData))
            {

                case Keys.Control:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.F4:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.Control | Keys.Delete:
                    {
                        return true;
                    }

                case Keys.Control | Keys.Q:
                    {
                        return true;
                    }
            }
            return base.ProcessDialogKey(keyData);
        }
        private void SimpleLock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && tries >= 3)
            {

                tries = 0;
                txbPassword.Enabled = true;
                txbPassword.Visible = true;
                txbPassword.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
            SendKeys.Send("{ESC}");
            if (!txbPassword.Focused) txbPassword.Focus();
        }
    }
}
