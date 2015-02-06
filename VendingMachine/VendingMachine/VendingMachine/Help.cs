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
            location = _location;
            using (WebClient Client = new WebClient())
            {
                while ( (Directory.Exists(Config.tempFileLocation)))
                {
                    Config.tempFileLocation = Path.Combine(Path.GetTempPath() + Guid.NewGuid().ToString());
                }
                Directory.CreateDirectory(Config.tempFileLocation);
                //MessageBox.Show(string.Format(Config.tempFileLocation + "/index.html"));
                Client.DownloadFile("https://raw.githubusercontent.com/minijack/College/master/VendingMachine/Assests/help.html", (Path.Combine(Config.tempFileLocation + "\\index.html")));
                
            }
        }

        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            helpBrowser.Navigate(Config.tempFileLocation + "\\index.html");
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
