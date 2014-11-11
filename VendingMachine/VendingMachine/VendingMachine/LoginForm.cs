using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
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
                    VendingMachine VendingMachine = new VendingMachine();
                    //VendingMachine.Init();
                    VendingMachine.Show();
                    this.Hide();
                }
            }
        }


    }
}
