using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendigMachine
{
    public class Candys : VendingMachine, IProduct
    {
        public string name;
        public int size;
        public string description;
        public string tag;
        public int price;

        public Candys(string name, int size, string description, string tag, int price)
        {
            this.name = name;
            this.size = size;
            this.description = description;
            this.tag = tag;
            this.price = price;
        }

        public bool Buy(string name, int insertedMoney)
        {
            if (insertedMoney < price) { Console.WriteLine("Please insert more money in the vendingmachine"); return false; }
            Console.WriteLine("You have purchased " + name);
            Use(name);
            return true;
        }

        public void Description(string description)
        {
            Console.WriteLine(description);
        }
        public void Use(string name)
        {
            Console.WriteLine("You just ate " + name);
        }
    }
}
