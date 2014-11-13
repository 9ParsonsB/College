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
            if (e.KeyChar == (char)13)
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
            if (txtUsr.Text == Config.User) 
            {
                if (txtPswd.Text == Config.Pass)
                {

                    VendingMachine VendingMachine = new VendingMachine(this);
                    this.Hide();
                    
                }
            }
        }

    }
}
