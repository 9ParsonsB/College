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
    static class Config
    {
        //public static List<VendingItem> ItemsBought { get; set; }
        //public static List<VendingItem> Items { get; set; }

        public static bool isLoading { get; set; }

        public static List<VendingItem> Items { get; set; }
        public static List<PictureBox> picList { get; set; }
        public static List<VendingItem> ItemsBought { get; set; }
        public static List<ToolTip> pBoxTip { get; set; }



        public static string User
        {
            get {return _User;}
        }
        public static string Pass
        {
            get { return _Pass; }
        }

        private static string _User = "root";
        private static string _Pass = "toor";
    }
}
