using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Product
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 1)
                {
                    _name = value.Trim();
                } else
                {
                    throw new Exception("Length must be greater than 1");
                }
            }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
        private string _code;

        public string Code
        {
            get { return _code; }
        }
         public Product(string code, string name, int price)
        {
            _code = code;
            Name = name;
            Price = price;
        }
    }
}
