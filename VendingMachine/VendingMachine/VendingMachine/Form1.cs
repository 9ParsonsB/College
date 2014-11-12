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
        List<VendingItem> Items = new List<VendingItem>();
        List<PictureBox> picList = new List<PictureBox>();
        List<VendingItem> ItemsBought = new List<VendingItem>();
        List<ToolTip> pBoxTip = new List<ToolTip>();
        SaveFileDialog saveFile = new SaveFileDialog();
        OpenFileDialog openFile = new OpenFileDialog();
        List<string> toSave = new List<string>();
        List<string> toLoad = new List<string>();
        Regex loadExp;
        Match match;
        public VendingMachineTask.LoginForm Sender;
        private decimal TotalCost;

        public VendingMachine(VendingMachineTask.LoginForm _sender)
        {
            InitializeComponent();
            Sender = _sender;
            Items.Add(new VendingItem("Cake", 3.5m, Image.FromFile("../Images/cake.png")));
            Items.Add(new VendingItem("Potato", 1.24m, Image.FromFile("../Images/Potato.png")));
            Items.Add(new VendingItem("Bird", 2.8m, Image.FromFile("../Images/bird.png")));
            Items.Add(new VendingItem("Mask", 10.8m, Image.FromFile("../Images/mask.png")));
            Items.Add(new VendingItem("Hat", 3.35m, Image.FromFile("../Images/hat2.png")));
            Items.Add(new VendingItem("Preserver", 2.13m, Image.FromFile("../Images/borealis.png")));
            Items.Add(new VendingItem("Cube", 5.15m, Image.FromFile("../Images/cube.png")));
            Items.Add(new VendingItem("Fez", 0.78m, Image.FromFile("../Images/fez.png")));

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            //System.Windows.Forms.ToolTip pBox1Tip = new System.Windows.Forms.ToolTip();

            


            for (var i =0;i < Items.Count(); i++)
            {
                pBoxTip.Add(new ToolTip());
            }
            
        }

        public void Init()
        {
            
            clearItems();

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
                
                picList[i].Image = Items[i].Image;
                pBoxTip[i].SetToolTip(picList[i], Items[i].Name + ": " + string.Format("{0:C}", Items[i].Price));
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
        }

        private void updateList()
        {
            this.lstItems.Items.Clear();
            this.lstItems.Columns.Clear();
            TotalCost = 0.0m;
            int i = 0;

            lstItems.Columns.Add("Name");
            lstItems.Columns.Add("Price");

            foreach (VendingItem x in ItemsBought)
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
                ItemsBought.Add(Items[x]);
                updateList();
            }
        }

        private int findItem(int x)
        {
            foreach (var i in picList.ToArray())
            {
                if (x < Items.Count())
                    if (i.Image == Items[x].Image)
                        return x;
            }
                return -1;
        }
    
        private int findItem(string x)
        {
            int z = -1;
            foreach (var i in ItemsBought.ToArray())
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
                
                foreach (var i in ItemsBought)
                {
                    if (lstItems.SelectedItems[0].Index == z)
                    {
                        Console.WriteLine("{0}: {1} | {2} HERE!!!!!!!", z, ItemsBought[z].Name, lstItems.Items[z].Text);
                        delete = z;
                    }
                    else
                    {
                        Console.WriteLine("{0}: {1} | {2}", z, ItemsBought[z].Name, lstItems.Items[z].Text);
                    }

                    z++;
                }
                Console.WriteLine("");
                Console.WriteLine("---End Bought Table---");
                Console.WriteLine("");
                
                
            }
            if (delete != -1)
                ItemsBought.RemoveAt(delete);
            updateList();
        }

        private bool clearItems()
        {
            if (ItemsBought.Count() != 0)
            {
                if (MessageBox.Show("Are you sure you want to clear your current order?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    ItemsBought = new List<VendingItem>();
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
                foreach (var i in ItemsBought)
                {
                    toSave.Add(i.Name + ": " + String.Format("{0:c}",i.Price));
                }



                toSave.Add("");
                toSave.Add("");
                toSave.Add(String.Format("Cost: £ {0}", String.Format("{0:c}",TotalCost)));
                toSave.Add(String.Format("Items: {0}", ItemsBought.Count().ToString()));

                File.WriteAllLines(saveFile.FileName, toSave.ToArray());
                
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsBought.Count() != 0)
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
                        foreach (var x in Items)
                        {
                            Console.WriteLine();
                            Console.WriteLine("looking for: \"" + match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)) + "\"");
                            Console.WriteLine("at: \"" + x.Name + "\"");

                            if (x.Name == match.Groups[0].Value.Substring(0,(match.Groups[0].Value.Length - 1)).ToString())
                            {
                                ItemsBought.Add(x);
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
