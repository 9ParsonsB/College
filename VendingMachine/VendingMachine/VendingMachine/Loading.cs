using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineTask
{
    public partial class Loading : Form
    {
        VendingMachine Sender;
        public Loading(VendingMachine _sender)
        {
            InitializeComponent();
            Sender = _sender;
            Init();
        }
        public void Init()
        {
            timer1.Enabled = true;
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = Config.progress.ToString();


            PbarLoading.Value = Config.progress;

            if (!(Config.isLoading))
            {
                Sender.Show();
                this.Close();
            }
        }

    }
}
