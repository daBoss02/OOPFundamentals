using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class VendingMachine
    {
        private int _serialNumber;

        private Dictionary<int, int> _moneyFloat = new Dictionary<int, int>();

        private Dictionary<Product, int> _inventory = new Dictionary<Product, int>();

        public void StockItem()
        {
            bool validItem = false;
            bool validName = false;
            string itemName = "";
            string price = "";


            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            char letter = letters[_inventory.Count / 10];
            int num = _inventory.Count % 10;
            string itemCode = $"{letter}{num}";

            Product toAdd = new Product(itemCode);
            while (!validName)
            {
                try
                {
                    Console.WriteLine("What item would you like to add:");
                    itemName = Console.ReadLine();
                    toAdd.Name = itemName;
                    validName = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            bool isThere = false;

            Product product1 = new Product("00");

            foreach (KeyValuePair<Product, int> product in _inventory)
            {
                if (product.Key.Name == itemName)
                {
                    validItem = true;
                    product1 = product.Key;
                    isThere = true;
                    break;
                }
            }


            while (!validItem)
            {
                try
                {
                    Console.WriteLine("What is the price?");
                    price = Console.ReadLine();
                    toAdd.Price = Int32.Parse(price);
                    validItem = true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            if (!isThere)
            {
                _inventory.Add(toAdd, 0);
                product1 = toAdd;
            }
            
            bool validAmount = false;

            int amount = 0;
            while (!validAmount)
            {
                Console.WriteLine("How many would you like to add");
                try
                {
                    amount = Int32.Parse(Console.ReadLine());
                    validAmount = true;
                } catch
                {
                    throw new Exception("Please input an integer amount");
                }
            }

            
            _inventory[product1] += amount;

        }

        public void printInv()
        {
            foreach (Product p in _inventory.Keys)
            {
                Console.WriteLine(p.Name + " " + _inventory[p]);
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
