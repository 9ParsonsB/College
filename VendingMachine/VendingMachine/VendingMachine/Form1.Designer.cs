namespace VendingMachineTask
{
    partial class VendingMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClr = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.pBox2 = new System.Windows.Forms.PictureBox();
            this.pBox3 = new System.Windows.Forms.PictureBox();
            this.pBox4 = new System.Windows.Forms.PictureBox();
            this.pBox5 = new System.Windows.Forms.PictureBox();
            this.pBox6 = new System.Windows.Forms.PictureBox();
            this.pBox7 = new System.Windows.Forms.PictureBox();
            this.pBox8 = new System.Windows.Forms.PictureBox();
            this.pBox9 = new System.Windows.Forms.PictureBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListView();
            this.btnBuy = new System.Windows.Forms.Button();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClr
            // 
            this.btnClr.Location = new System.Drawing.Point(439, 37);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(75, 23);
            this.btnClr.TabIndex = 2;
            this.btnClr.Text = "Clear";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(439, 66);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(529, 24);
            this.menuBar.TabIndex = 4;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help!";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pBox1
            // 
            this.pBox1.InitialImage = null;
            this.pBox1.Location = new System.Drawing.Point(12, 37);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(92, 84);
            this.pBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox1.TabIndex = 0;
            this.pBox1.TabStop = false;
            this.pBox1.Click += new System.EventHandler(this.pBox1_Click);
            // 
            // pBox2
            // 
            this.pBox2.Location = new System.Drawing.Point(110, 37);
            this.pBox2.Name = "pBox2";
            this.pBox2.Size = new System.Drawing.Size(92, 84);
            this.pBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox2.TabIndex = 1;
            this.pBox2.TabStop = false;
            this.pBox2.Click += new System.EventHandler(this.pBox2_Click);
            // 
            // pBox3
            // 
            this.pBox3.Location = new System.Drawing.Point(208, 37);
            this.pBox3.Name = "pBox3";
            this.pBox3.Size = new System.Drawing.Size(92, 84);
            this.pBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox3.TabIndex = 2;
            this.pBox3.TabStop = false;
            this.pBox3.Click += new System.EventHandler(this.pBox3_Click);
            // 
            // pBox4
            // 
            this.pBox4.Location = new System.Drawing.Point(12, 127);
            this.pBox4.Name = "pBox4";
            this.pBox4.Size = new System.Drawing.Size(92, 84);
            this.pBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox4.TabIndex = 3;
            this.pBox4.TabStop = false;
            this.pBox4.Click += new System.EventHandler(this.pBox4_Click);
            // 
            // pBox5
            // 
            this.pBox5.InitialImage = null;
            this.pBox5.Location = new System.Drawing.Point(110, 127);
            this.pBox5.Name = "pBox5";
            this.pBox5.Size = new System.Drawing.Size(92, 84);
            this.pBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox5.TabIndex = 4;
            this.pBox5.TabStop = false;
            this.pBox5.Click += new System.EventHandler(this.pBox5_Click);
            // 
            // pBox6
            // 
            this.pBox6.Location = new System.Drawing.Point(208, 127);
            this.pBox6.Name = "pBox6";
            this.pBox6.Size = new System.Drawing.Size(92, 84);
            this.pBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox6.TabIndex = 5;
            this.pBox6.TabStop = false;
            this.pBox6.Click += new System.EventHandler(this.pBox6_Click);
            // 
            // pBox7
            // 
            this.pBox7.Location = new System.Drawing.Point(12, 217);
            this.pBox7.Name = "pBox7";
            this.pBox7.Size = new System.Drawing.Size(92, 84);
            this.pBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox7.TabIndex = 6;
            this.pBox7.TabStop = false;
            this.pBox7.Click += new System.EventHandler(this.pBox7_Click);
            // 
            // pBox8
            // 
            this.pBox8.Location = new System.Drawing.Point(110, 217);
            this.pBox8.Name = "pBox8";
            this.pBox8.Size = new System.Drawing.Size(92, 84);
            this.pBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox8.TabIndex = 7;
            this.pBox8.TabStop = false;
            this.pBox8.Click += new System.EventHandler(this.pBox8_Click);
            // 
            // pBox9
            // 
            this.pBox9.Location = new System.Drawing.Point(208, 217);
            this.pBox9.Name = "pBox9";
            this.pBox9.Size = new System.Drawing.Size(92, 84);
            this.pBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox9.TabIndex = 8;
            this.pBox9.TabStop = false;
            this.pBox9.Click += new System.EventHandler(this.pBox9_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(439, 108);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(46, 13);
            this.lblCost.TabIndex = 9;
            this.lblCost.Text = "Cost: £0";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(439, 127);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(44, 13);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "Items: 0";
            // 
            // lstItems
            // 
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(306, 37);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(127, 264);
            this.lstItems.TabIndex = 11;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(442, 177);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 124);
            this.btnBuy.TabIndex = 12;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // VendingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 319);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.pBox9);
            this.Controls.Add(this.pBox8);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.pBox7);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.pBox6);
            this.Controls.Add(this.pBox5);
            this.Controls.Add(this.pBox4);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.pBox3);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.pBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuBar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendingMachine";
            this.Text = "Vending Machine";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.PictureBox pBox2;
        private System.Windows.Forms.PictureBox pBox3;
        private System.Windows.Forms.PictureBox pBox4;
        private System.Windows.Forms.PictureBox pBox5;
        private System.Windows.Forms.PictureBox pBox6;
        private System.Windows.Forms.PictureBox pBox7;
        private System.Windows.Forms.PictureBox pBox8;
        private System.Windows.Forms.PictureBox pBox9;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.Button btnBuy;
    }
}

