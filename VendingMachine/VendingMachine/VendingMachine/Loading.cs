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
        int Progress;
        int Incriment;
        VendingMachine Sender;
        public Loading(VendingMachine _sender)
        {
            InitializeComponent();
            Sender = _sender;
            Init();
        }
        public void Init()
        {
            Progress = 0;
            Incriment = 1;
            timer1.Enabled = true;
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Progress += Incriment;

            if (Progress == 100)
            {
                Progress= 0;
            }

            PbarLoading.Value = Progress;

            if (!(Config.isLoading))
            {
                Sender.Show();
                this.Close();
            }
        }

    }
}
