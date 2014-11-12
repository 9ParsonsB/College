using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTask
{
    static class Config
    {
        //public static List<VendingItem> ItemsBought { get; set; }
        //public static List<VendingItem> Items { get; set; }

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
