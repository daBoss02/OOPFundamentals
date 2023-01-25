using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Product
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 1)
                {
                    _name = value;
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
         public Product(string code)
        {
            _code = code;
        }
    }
}
