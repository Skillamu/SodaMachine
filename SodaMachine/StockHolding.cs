﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class StockHolding
    {
        public Drink[] Drinks;

        public StockHolding()
        {
            Drinks = new Drink[]
            {
                new Drink("Coca Cola", 20, 10),
                new Drink("Fanta", 5, 10),
                new Drink("Villa", 10, 10)
            };
        }

        public void ShowAllProductsAndPrices()
        {
            var productNum = 1;
            foreach (var drink in Drinks)
            {
                Console.WriteLine($"{productNum.ToString().PadLeft(2, '0')}: {drink.Name} : {drink.Price}kr");
                productNum++;
            }
        }

        public int GetPriceOfProduct(int index)
        {
            return Drinks[index].Price;
        }

        /*public void ReduceQuantityOfProduct(int index)
        {
            Drinks[index].ReduceQuantity();
            Console.WriteLine($"Antall igjen: {Drinks[index].Quantity}");
        }*/
    }
}
