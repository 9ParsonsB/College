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
using System.Net;


namespace VendingMachineTask
{
    public partial class Help : Form
    {
        private string location;

        public void init(string _location)
        {
            WebBrowser helpBrowser = new WebBrowser();
            helpBrowser.Navigate(new Uri("http://www.google.com"));

            helpBrowser.Navigate("http://www.makeuseof.com/answers/why-do-i-keep-getting-active-x-warnings/");
        }

        public Help()
        {
            InitializeComponent();
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            e.Cancel = true;
            // Confirm user wants to close
            this.Hide();
        }
    }
}
