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
    public class VendingItem
    {
        public string Name;
        public decimal Price;
        public string URL;

        public VendingItem(string _name, decimal _price, string _url)
        {
            Name = _name;
            Price = _price;
            URL = _url;
        }

    }

    public class WorkerReturnType
    {
        public List<VendingItem> Items;
        public List<PictureBox> picList;
        public List<VendingItem> ItemsBought;
        public List<ToolTip> pBoxTip;

    }

    public class TimeoutType
    {
        private int _value = 0;

        public int Get()
        {
            return _value;
        }

        public void Add(int amount)
        {
            _value += amount;
        }

        public void Tick()
        {
            if (_value > 0)
            {
                _value--;
            }
        }
    }
}
