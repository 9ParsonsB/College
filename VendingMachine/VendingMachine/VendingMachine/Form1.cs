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
    public partial class VendingMachine : Form
    {
        public static LoginForm Login = new LoginForm();

        public VendingMachine()
        {
            InitializeComponent();
        }

        private void Init()
        {
            clearItems();
            Config.Items.Add(new VendingItem("Cake",3.5,Image.FromFile("../Images/cake.png")));
            Config.Items.Add(new VendingItem("Potato", 1.24, Image.FromFile("../Images/Potato.png")));
            Config.Items.Add(new VendingItem("bird", 2.8, Image.FromFile("../Images/bird.png")));

            for (var i = 0; i < Config.Items.Count(); i++)
            {

            }
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            //pBox1.Image = Image.FromFile("../Images/cake.png");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            clearItems();
        }
        private void clearItems()
        {
            Config.ItemsBought = new List<VendingItem>();
        }
    }
}
