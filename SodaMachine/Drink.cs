using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class Drink
    {
        public string Name { get; }
        public int Price { get; }

        public Drink(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
