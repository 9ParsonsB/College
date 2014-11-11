using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VendingMachine
{
    class VendingItem
    {
        public string name;
        public double price;
        public Image image;

        public VendingItem(string _name, double _price, Image _image)
        {
            name = _name;
            price = Convert.ToDouble(_price);
            image = _image;
        }

    }
}
