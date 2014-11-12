using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VendingMachineTask
{
    class VendingItem
    {
        public string Name;
        public decimal Price;
        public Image Image;

        public VendingItem(string _name, decimal _price, Image _image)
        {
            Name = _name;
            Price = _price;
            Image = _image;
        }

    }
}
