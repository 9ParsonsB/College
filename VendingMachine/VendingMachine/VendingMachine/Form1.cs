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
    public partial class VendingMachine : Form
    {
        public static LoginForm Login = new LoginForm();

        SaveFileDialog saveFile = new SaveFileDialog();
        OpenFileDialog openFile = new OpenFileDialog();
        List<string> toSave = new List<string>();
        List<string> toLoad = new List<string>();
        Regex loadExp;
        Match match;
        public VendingMachineTask.LoginForm Sender;
        private decimal TotalCost;
        public Loading Loading;
        public Thread loadingThread;
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public VendingMachine(VendingMachineTask.LoginForm _sender)
        {
            InitializeComponent();
            Config.isLoading = true;
            Sender = _sender;
            LoadImages(this);




            
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerReturnType re = Init();

            Config.picList = re.picList;
            Config.pBoxTip = re.pBoxTip;
            Config.ItemsBought = re.ItemsBought;
            Config.Items = re.Items;
        }

        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {

            for (var i = 0; i < (Config.Items.Count); i++)
            {

                Config.pBoxTip[i].SetToolTip(Config.picList[i], Config.Items[i].Name + ": " + string.Format("{0:C}", Config.Items[i].Price));
            }


            Config.isLoading = false;
        }




        public void LoadImages(VendingMachine Sender)
        {
            Loading LoadingForm = new Loading(Sender);
            LoadingForm.Show();
        }

        public WorkerReturnType Init()
        {


            List<VendingItem> Items = new List<VendingItem>();
            List<PictureBox> picList = new List<PictureBox>();
            List<VendingItem> ItemsBought = new List<VendingItem>();
            List<ToolTip> pBoxTip = new List<ToolTip>();


            Items.Add(new VendingItem("Cake", 3.5m, "http://puu.sh/cOaEs/0b6478f1a5.png"));
            Items.Add(new VendingItem("Potato", 1.24m, "http://puu.sh/cObfS/7cd34d8793.png"));
            Items.Add(new VendingItem("Bird", 2.8m, "http://puu.sh/cOaCf/7a9526184d.png"));
            Items.Add(new VendingItem("Mask", 10.8m, "http://puu.sh/cObfb/681eff4371.png"));
            Items.Add(new VendingItem("Hat", 3.35m, "http://puu.sh/cObdE/847fe8ee84.png"));
            Items.Add(new VendingItem("Preserver", 2.13m, "http://puu.sh/cOaDC/2be0641566.png"));
            Items.Add(new VendingItem("Cube", 5.15m, "http://puu.sh/cOaEV/9d6c8f93ab.png"));
            Items.Add(new VendingItem("Fez", 0.78m, "http://puu.sh/cOaFe/1d07104990.png"));


            

            picList.Add(pBox1);
            picList.Add(pBox2);
            picList.Add(pBox3);
            picList.Add(pBox4);
            picList.Add(pBox5);
            picList.Add(pBox6);
            picList.Add(pBox7);
            picList.Add(pBox8);
            picList.Add(pBox9);

            for (var i = 0; i < (Items.Count); i++)
            {

                picList[i].Load(Items[i].URL);

                pBoxTip.Add(new ToolTip());
            }


            for (var i = 0; i < picList.Count(); i++)
            {
                switch (i)
                {
                    case 1:
                        pBox1 = picList[i];
                        break;
                    case 2:
                        pBox2 = picList[i];
                        break;
                    case 3:
                        pBox3 = picList[i];
                        break;
                    case 4:
                        pBox4 = picList[i];
                        break;
                    case 5:
                        pBox5 = picList[i];
                        break;
                    case 6:
                        pBox6 = picList[i];
                        break;
                    case 7:
                        pBox7 = picList[i];
                        break;
                    case 8:
                        pBox8 = picList[i];
                        break;
                    case 9:
                        pBox9 = picList[i];
                        break;

                }
            }


            Config.isLoading = false;

            WorkerReturnType re = new WorkerReturnType();

            MessageBox.Show("done!");
            re.Items = Items;
            re.ItemsBought = ItemsBought;
            re.pBoxTip = pBoxTip;
            re.picList = picList;
            return re;
        }

        private void updateList()
        {
            this.lstItems.Items.Clear();
            this.lstItems.Columns.Clear();
            TotalCost = 0.0m;
            int i = 0;

            lstItems.Columns.Add("Name");
            lstItems.Columns.Add("Price");

            foreach (VendingItem x in Config.ItemsBought)
            {
                var item = new ListViewItem(new[] { x.Name, String.Format("{0:c}",  x.Price) });

                lstItems.Items.Add(item);
                
                i++;
                TotalCost += x.Price;

            }

            lblCost.Text = String.Format("Cost: £ {0}", String.Format("{0:c}",TotalCost));
            lblCount.Text = String.Format("Items: {0}", i.ToString());

        }



        private void addItem(int x)
        {
            x = x - 1; // arrays start at 0, not 1
            //x = findItem(x);
            if (x == -1)
                Console.WriteLine("cannot find item by image!");
            else
            {
                Config.ItemsBought.Add(Config.Items[x]);
                updateList();
            }
        }

        /*private int findItem(int x)
        {
            foreach (var i in picList.ToArray())
            {
                if (x < Items.Count())
                    if (i.Image == Items[x].Image)
                        return x;
            }
                return -1;
        }//*/
    
        private int findItem(string x)
        {
            int z = -1;
            foreach (var i in Config.ItemsBought.ToArray())
            {
                z = -1;
                if (i.Name == x)
                {
                    z++;
                }
            }
            return z;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            clearItems();
            updateList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int delete = -1;
            if (lstItems.SelectedItems.Count == 1)
            {
                int itemIndex = lstItems.SelectedItems[0].Index;
                Console.WriteLine(itemIndex);
                
                Console.WriteLine("");
                Console.WriteLine("---Start Bought Table---");
                Console.WriteLine("");
                var z = 0;

                foreach (var i in Config.ItemsBought)
                {
                    if (lstItems.SelectedItems[0].Index == z)
                    {
                        Console.WriteLine("{0}: {1} | {2} HERE!!!!!!!", z, Config.ItemsBought[z].Name, lstItems.Items[z].Text);
                        delete = z;
                    }
                    else
                    {
                        Console.WriteLine("{0}: {1} | {2}", z, Config.ItemsBought[z].Name, lstItems.Items[z].Text);
                    }

                    z++;
                }
                Console.WriteLine("");
                Console.WriteLine("---End Bought Table---");
                Console.WriteLine("");
                
                
            }
            if (delete != -1)
                Config.ItemsBought.RemoveAt(delete);
            updateList();
        }

        private bool clearItems()
        {
            if (Config.ItemsBought.Count() != 0)
            {
                if (MessageBox.Show("Are you sure you want to clear your current order?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    Config.ItemsBought = new List<VendingItem>();
                    updateList();
                    return true;
                }
            }
            return false;
        }

        private void pBox1_Click(object sender, EventArgs e)
        {
            addItem(1);
        }
        private void pBox2_Click(object sender, EventArgs e)
        {
            addItem(2);
        }
        private void pBox3_Click(object sender, EventArgs e)
        {
            addItem(3);
        }
        private void pBox4_Click(object sender, EventArgs e)
        {
            addItem(4);
        }
        private void pBox5_Click(object sender, EventArgs e)
        {
            addItem(5);
        }
        private void pBox6_Click(object sender, EventArgs e)
        {
            addItem(6);
        }
        private void pBox7_Click(object sender, EventArgs e)
        {
            addItem(7);
        }
        private void pBox8_Click(object sender, EventArgs e)
        {
            addItem(8);
        }
        private void pBox9_Click(object sender, EventArgs e)
        {
            addItem(9);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            Sender.Show();
            Sender.Close();
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            toSave = new List<string>();

            saveFile.FileName = "Vending Order.txt";
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var i in Config.ItemsBought)
                {
                    toSave.Add(i.Name + ": " + String.Format("{0:c}",i.Price));
                }



                toSave.Add("");
                toSave.Add("");
                toSave.Add(String.Format("Cost: £ {0}", String.Format("{0:c}",TotalCost)));
                toSave.Add(String.Format("Items: {0}", Config.ItemsBought.Count().ToString()));

                File.WriteAllLines(saveFile.FileName, toSave.ToArray());
                
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Config.ItemsBought.Count() != 0)
            {
                if (clearItems())
                {
                    loadFile();
                }
            }
            else
            {
                loadFile();
            }
            updateList();
           
        }


        void loadFile()
        {
            loadExp = new Regex(@"\w*:");
            openFile = new OpenFileDialog();
            toLoad = new List<string>();

            Console.WriteLine("loading File!");
            openFile.Title = "Open Order File";
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var i in File.ReadAllLines(openFile.FileName))
                {
                    toLoad.Add(i);
                }
                   
                

                foreach (var i in toLoad.ToArray())
                {
                    match = loadExp.Match(i);
                    if (match.Success)
                    {
                        foreach (var x in Config.Items)
                        {
                            Console.WriteLine();
                            Console.WriteLine("looking for: \"" + match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)) + "\"");
                            Console.WriteLine("at: \"" + x.Name + "\"");

                            if (x.Name == match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)).ToString())
                            {
                                Config.ItemsBought.Add(x);
                                Console.WriteLine("Found! \"" + x.Name + "\" With: \"" + match.Groups[0].Value.Substring(0, (match.Groups[0].Value.Length - 1)) + "\"");
                            }
                            else
                            {
                                //Console.WriteLine("Not Found!");
                            }
                        }
                        
                    }
                }

            }

            Console.WriteLine("no longer loading file!");
        }

    }
}
