using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class StockHolding
    {
        public int Cash { get; private set; }
        public Drink[] Drinks { get; private set; }

        public StockHolding()
        {
            Drinks = new Drink[]
            {
                new Drink("Coca Cola", 20, 10),
                new Drink("Fanta", 5, 10),
                new Drink("Villa", 10, 10),
                new Drink("Pepsi", 30, 10)
            };
        }

        public void DecreaseCash(int amount)
        {
            Cash -= amount;
        }

        public void IncreaseCash(int amount)
        {
            Cash += amount;
        }
    }
}
