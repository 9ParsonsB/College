using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace VendingMachineTask
{
    public partial class LoginForm : Form
    {
        private int iAttempts = 0;
        private int iMaxAttempts = 2;
        private string sUserInput;
        private string sPassInput;
        private TimeoutType tTimeout = new TimeoutType();

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void Login(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtPswd.Enabled) // if the user presses Enter and the password box is enabled
            {
                verifyLogin();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            verifyLogin();
        }

        private void verifyLogin()
        {
            sUserInput = txtUsr.Text;
            sPassInput = txtPswd.Text;
            iAttempts++;
            if (sUserInput == Config.User) // if username is correct
            {
                if (sPassInput == Config.Pass) // and password
                {
                    VendingMachineTask.Help helpForm = new VendingMachineTask.Help();
                    VendingMachine VendingMachine = new VendingMachine(this,helpForm); // open the vending machine (does not show the form)
                    this.Hide(); // hide login form

                    txtPswd.Text = ""; // reset the username & password feilds
                    txtUsr.Text = "";
                    iAttempts = 0; // reset attempts count
                    
                } else { MessageBox.Show("Incorrect password!","Login attempts fail",MessageBoxButtons.OK,MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1); }
            } else  { MessageBox.Show("Incorrect username!","Login attempts fail",MessageBoxButtons.OK,MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1); }
            if (iAttempts > iMaxAttempts)
            {
                txtPswd.Enabled = false;
                tTimeout.Add(5);
            }
        }

        private void tmrTimeout_Tick(object sender, EventArgs e)
        {
            tTimeout.Tick();
            if (tTimeout.Get() == 0)
            {
                txtPswd.Enabled = true;
                iAttempts = 0;
            }
        }

        private void lblPswd_Click(object sender, EventArgs e)
        {
            // Debug trigger, insert debug code here
            //Help help = new Help();
            //help.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Config.tempFileLocation = Path.Combine(Path.GetTempPath() + Guid.NewGuid().ToString());
        }

        private void lblUsr_Click(object sender, EventArgs e)
        {
            // Debug trigger, insert debug code here
        }
    }
}
