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
using System.Text.RegularExpressions;

namespace VendingMachineTask
{
    public partial class LoginForm : Form
    {
        
        
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void Login(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // if the user presses Enter
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
            if (txtUsr.Text == Config.User) // if username is correct
            {
                if (txtPswd.Text == Config.Pass) // and password
                {

                    VendingMachine VendingMachine = new VendingMachine(this); // open the vending machine
                    this.Hide(); // hide login form

                    txtPswd.Text = ""; // reset the username & password feilds
                    txtUsr.Text = "";
                    
                }
            }
        }

    }
}
