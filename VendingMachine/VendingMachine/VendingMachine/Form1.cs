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





            // setup background worker

            worker.DoWork += worker_DoWork; // events for background worker
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync(); // start worker

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB"); // set currency

            
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                WorkerReturnType re = Init();

                Config.picList = re.picList; // set values from return type
                Config.pBoxTip = re.pBoxTip;
                Config.ItemsBought = re.ItemsBought;
                Config.Items = re.Items;

            }//*/
            catch (System.Net.WebException) // if cannot connect to the internet
            {
                Config.isLoading = false; // stop loading form
                MessageBox.Show("Error, You MUST be connected to the internet to download content", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1); // tell user that there is no internet connection

                // create instance of lists
                Config.Items = new List<VendingItem>();
                Config.picList = new List<PictureBox>();
                Config.ItemsBought = new List<VendingItem>();
                Config.pBoxTip = new List<ToolTip>();

                Config.picList.Add(pBox1); // add pictureboxs to List
                Config.picList.Add(pBox2);
                Config.picList.Add(pBox3);
                Config.picList.Add(pBox4);
                Config.picList.Add(pBox5);
                Config.picList.Add(pBox6);
                Config.picList.Add(pBox7);
                Config.picList.Add(pBox8);
                Config.picList.Add(pBox9);

                
                Random Rnd = new Random();

                // choose a random image from windows default pictures and add it as an item
                Config.Items.Add(new VendingItem("defualt", 0.0m, "C:/ProgramData/Microsoft/User Account Pictures/Default Pictures/usertile"+ Rnd.Next(10,44).ToString()+".bmp"));

                for (var i = 0; i < (Config.Items.Count); i++) // for each of the items
            {

                Config.picList[i].Image = Image.FromFile(Config.Items[i].URL); // add the image

                Config.pBoxTip.Add(new ToolTip()); // add the tool tip
            }

            }

            

        }




        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {

            for (var i = 0; i < (Config.Items.Count); i++) // for each of the items
            {

                Config.pBoxTip[i].SetToolTip(Config.picList[i], Config.Items[i].Name + ": " + string.Format("{0:C}", Config.Items[i].Price)); // set tooltip
            }


            Config.isLoading = false; // stop loadingform
        }




        public void LoadImages(VendingMachine Sender)
        {
            Loading LoadingForm = new Loading(Sender); // create instance of loadingform
            LoadingForm.Show(); // show loading form
        }

        public WorkerReturnType Init()
        {
            Config.progress = 0; // set progress to 0

            List<VendingItem> Items = new List<VendingItem>(); // array of items to choose from
            List<PictureBox> picList = new List<PictureBox>(); //array of pictureboxes (temporary)
            List<VendingItem> ItemsBought = new List<VendingItem>(); // array of items bought
            List<ToolTip> pBoxTip = new List<ToolTip>(); // array of tooltips


            // add items you can buy to the array, including their price and image location (URL)
            Items.Add(new VendingItem("Cake", 3.5m, "http://puu.sh/cOaEs/0b6478f1a5.png"));
            Items.Add(new VendingItem("Potato", 1.24m, "http://puu.sh/cObfS/7cd34d8793.png"));
            Items.Add(new VendingItem("Bird", 2.8m, "http://puu.sh/cOaCf/7a9526184d.png"));
            Items.Add(new VendingItem("Mask", 10.8m, "http://puu.sh/cObfb/681eff4371.png"));
            Items.Add(new VendingItem("Hat", 3.35m, "http://puu.sh/cObdE/847fe8ee84.png"));
            Items.Add(new VendingItem("Preserver", 2.13m, "http://puu.sh/cOaDC/2be0641566.png"));
            Items.Add(new VendingItem("Cube", 5.15m, "http://puu.sh/cOaEV/9d6c8f93ab.png"));
            Items.Add(new VendingItem("Fez", 0.78m, "http://puu.sh/cOaFe/1d07104990.png"));
            Items.Add(new VendingItem("Heart", 0.25m, "http://puu.sh/cOuHp/059a3fe094.png"));

            
            // add pictureboxes to temporary array
            picList.Add(pBox1);
            picList.Add(pBox2);
            picList.Add(pBox3);
            picList.Add(pBox4);
            picList.Add(pBox5);
            picList.Add(pBox6);
            picList.Add(pBox7);
            picList.Add(pBox8);
            picList.Add(pBox9);

            for (var i = 0; i < (Items.Count); i++) // for each entry in the item array
            {

                picList[i].Load(Items[i].URL); // load the image onto the picture box
                Config.progress += 10; // add to progress (for loadin form)
                pBoxTip.Add(new ToolTip()); // create empty tooltip
            }


            for (var i = 0; i < picList.Count(); i++) // loop through the array of pictureboxes
            {
                switch (i)
                {
                    case 1:
                        pBox1 = picList[i]; // set each picturebox to each element in the array of pictureboxes
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
            Config.progress += 10;

            Config.isLoading = false; // tell the loading form to stop

            WorkerReturnType re = new WorkerReturnType(); // create return type

            re.Items = Items;
            re.ItemsBought = ItemsBought;
            re.pBoxTip = pBoxTip;
            re.picList = picList;

            return re;
        }

        private void updateList()
        {
            this.lstItems.Items.Clear(); // clear the items in the listbox
            this.lstItems.Columns.Clear(); // clear columns in the listbox
            TotalCost = 0.0m; // clear total cost
            int i = 0; // reset iterator

            lstItems.Columns.Add("Name"); // add columns
            lstItems.Columns.Add("Price");

            foreach (VendingItem x in Config.ItemsBought) // for each of the items bought
            {
                var item = new ListViewItem(new[] { x.Name, String.Format("{0:c}",  x.Price) });

                lstItems.Items.Add(item); // add the items to the list box

                i++; // incriment iterator
                TotalCost += x.Price; // add to total price

            }

            lblCost.Text = String.Format("Cost: £ {0}", String.Format("{0:c}",TotalCost)); // set labels so user knows the total cost & items
            lblCount.Text = String.Format("Items: {0}", i.ToString());

        }



        private void addItem(int x)
        {
            x = x - 1; // arrays start at 0, not 1

            if (x == -1) // if an error occurs
                Console.WriteLine("cannot find item by image!");
            else
            {
                Config.ItemsBought.Add(Config.Items[x]); // add the items to the list of items bought
                updateList(); // update the list of items
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e) // logout button handler
        {
            this.Close(); // close current window
            Sender.Show(); // show the login form
        }

        private void btnClr_Click(object sender, EventArgs e) // clear button
        {
            clearItems(); // clear bought item
            updateList(); // update bought items list
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int delete = -1;
            if (lstItems.SelectedItems.Count == 1) // if you have an item selected in the listbox
            {
                int itemIndex = lstItems.SelectedItems[0].Index;
                Console.WriteLine(itemIndex);
                
                Console.WriteLine("");
                Console.WriteLine("---Start Bought Table---");
                Console.WriteLine("");
                var z = 0;

                foreach (var i in Config.ItemsBought) // for each of the items ought
                {
                    if (lstItems.SelectedItems[0].Index == z) // if the index of the items selected is the same as the item being looped through
                    {
                        Console.WriteLine("{0}: {1} | {2} HERE!!!!!!!", z, Config.ItemsBought[z].Name, lstItems.Items[z].Text); // debug table
                        delete = z; // remember to delete this index
                    }
                    else
                    {
                        Console.WriteLine("{0}: {1} | {2}", z, Config.ItemsBought[z].Name, lstItems.Items[z].Text); // debug table
                    }

                    z++; // incriment iterator
                }
                Console.WriteLine("");
                Console.WriteLine("---End Bought Table---");
                Console.WriteLine("");
                
                
            }
            if (delete != -1) // if we found the correct item to delete
                Config.ItemsBought.RemoveAt(delete); // remove it from the array
            updateList(); // update the list of items bought
        }

        private bool clearItems()
        {
            if (Config.ItemsBought.Count() != 0) // if the amount of items bought is not 0
            {
                // ask the user if they are sure that they want to delete the current order
                if (MessageBox.Show("Are you sure you want to clear your current order?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    Config.ItemsBought = new List<VendingItem>();// if yes, create new instance of the array, overwriting the old one
                    updateList(); // update the list of items bought
                    return true;
                }
            }
            return false;
        }

        private void pBox1_Click(object sender, EventArgs e) // picturebox click event handler
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

        protected override void OnFormClosing(FormClosingEventArgs e) // if the user clicks the X button
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            Sender.Show(); // show the login form
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) // handle new order button
        {
            clearItems(); // clear bought items
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // save handler
        {
            saveFile = new SaveFileDialog(); // create saveFileDialog instance
            toSave = new List<string>(); // list of lines to save to file

            saveFile.FileName = "Vending Order.txt"; // defualt file name
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // filter for save file dialog

            if (saveFile.ShowDialog() == DialogResult.OK) // prompt user for save location, if they press OK then
            {
                foreach (var i in Config.ItemsBought) // for each of the items bought
                {
                    toSave.Add(i.Name + ": " + String.Format("{0:c}",i.Price)); // add it to the list of lines to be wrote to file
                }



                toSave.Add(""); // empty lines
                toSave.Add("");
                toSave.Add(String.Format("Cost: £ {0}", String.Format("{0:c}",TotalCost))); // add total cost
                toSave.Add(String.Format("Items: {0}", Config.ItemsBought.Count().ToString())); // add number of items

                File.WriteAllLines(saveFile.FileName, toSave.ToArray()); // write all lines to file
                
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)// handle load button
        {
            if (Config.ItemsBought.Count() != 0) // if the amount of items is not 0
            {
                if (clearItems()) // if cleared all items
                {
                    loadFile(); // load from file
                }
            }
            else // if there are no items bought
            {
                loadFile(); // load file anyway
            }
            updateList(); // after load file, update display
           
        }


        void loadFile()
        {
            loadExp = new Regex(@"\w*:"); // regular expression for "any character any amount of times with a colon after it"
            openFile = new OpenFileDialog(); // create openFileDialog instance
            toLoad = new List<string>(); // list of lines in the file that we are loading

            Console.WriteLine("loading File!");

            openFile.Title = "Open Order File"; // title of the dialog box
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // filter the dialog box
            if (openFile.ShowDialog() == DialogResult.OK) // if the pressed OK
            {
                foreach (var i in File.ReadAllLines(openFile.FileName)) // read all the lines in the file
                {
                    toLoad.Add(i); // add them to the list
                }
                   
                

                foreach (var i in toLoad.ToArray()) // for each item in the list
                {
                    match = loadExp.Match(i); // apply regular expression to string
                    if (match.Success) // if found a match
                    {
                        foreach (var x in Config.Items) // for each item
                        {
                            Console.WriteLine();
                            Console.WriteLine("looking for: \"" + match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)) + "\"");
                            Console.WriteLine("at: \"" + x.Name + "\"");

                            if (x.Name == match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)).ToString()) // if the name of the item is the same as the file (with some formatting)
                            {
                                Config.ItemsBought.Add(x); // add it to the items bought list
                                Console.WriteLine("Found! \"" + x.Name + "\" With: \"" + match.Groups[0].Value.Substring(0, (match.Groups[0].Value.Length - 1)) + "\""); // debug info
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

        private void btnBuy_Click(object sender, EventArgs e) // buy button handler
        {
            clearItems(); // clear bought items
        }

    }
}
