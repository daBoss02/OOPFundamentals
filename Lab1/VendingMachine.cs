using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab1
{
    public class VendingMachine
    {
        private static int _serialNumber;

        public int codeCount = 0;

        private Dictionary<int, int> _moneyFloat = new Dictionary<int, int>();

        private Dictionary<Product, int> _inventory = new Dictionary<Product, int>();

        public int getInventoryLength()
        {
            return _inventory.Count;
        }

        public void StockItem(Product product, int quantity)
        {
            bool alreadyThere = false;
            foreach (Product p in _inventory.Keys)
            {
                if (p.Name == product.Name)
                {
                    alreadyThere = true;
                    product = p;
                    break;
                }

            }
            if (!alreadyThere)
            {
                _inventory.Add(product, quantity);
                codeCount++;
            } else
            {
                _inventory[product] += quantity;
            }
        }

        public void StockFloat(int moneyDenomination, int quantity)
        {
            if (!_moneyFloat.ContainsKey(moneyDenomination))
            {
                _moneyFloat.Add(moneyDenomination, quantity);
            } else
            {
                _moneyFloat[moneyDenomination] += quantity;
            }
        }
        
        
        public void printInv()
        {
            foreach (Product p in _inventory.Keys)
            {
                Console.WriteLine($"{p.Code}: {p.Name}");
            }

        }

        public void printMoney()
        {
            foreach (KeyValuePair<int, int> coin in _moneyFloat)
            {
                Console.WriteLine(coin.Key + ": " + coin.Value);
            }

        }

        public void VendItem(string code, int money)
        {
            Product item = new Product("empty", "empty", 0);
            bool validVend = true;
            try
            {
                foreach (Product p in _inventory.Keys)
                {
                    if (p.Code == code)
                    {
                        item = p;
                        break;
                    }
                }
            } catch
            { 
                throw new Exception($"Code: '{code}' does not exist \n" +
                    $"Please choose from 'A0' to '{_inventory.Keys.Last().Code}'");
            }
            
            if (_inventory[item] == 0)
            {
                throw new Exception($"Error: {item.Name} is/are out of stock");
            }
            if (item.Price > money)
            {
                throw new Exception($"Error: insufficient funds");
            }

            // get change
            int change = money - item.Price;
            Dictionary<int, int> owed = new Dictionary<int, int>();
            if (change == 0) { Console.WriteLine("There is no change"); }
            else
            {
                Console.WriteLine($"You are owed ${change}");
                foreach (KeyValuePair<int, int> coin in _moneyFloat)
                {
                    while (change - coin.Key >= 0 && _moneyFloat[coin.Key] != 0)
                    {
                        if (!owed.ContainsKey(coin.Key))
                        {
                            owed.Add(coin.Key, 0);
                        }
                        change -= coin.Key;
                        owed[coin.Key]++;
                        _moneyFloat[coin.Key]--;
                    }
                }
                if (change > 0)
                {
                    Console.WriteLine("Error: Insufficient change");
                }
                else
                {
                    foreach (KeyValuePair<int, int> coin in owed)
                    {
                        Console.WriteLine($"${coin.Key}: {coin.Value}");
                    }
                }

            }
        }

        public VendingMachine(Dictionary <int, int> moneyFloat)
        {
            _moneyFloat = moneyFloat;
            Random randNum = new Random();
            _serialNumber = randNum.Next(100_000, 1_000_000);
        }
    }
}
