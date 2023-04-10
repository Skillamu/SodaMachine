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
        public int Quantity { get; private set; }

        public Drink(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        /*public void ReduceQuantity()
        {
            Quantity--;
        }*/
    }
}
