using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class Machine
    {
        public int Cash { get; private set; }
        private StockHolding _stockHolding;

        public Machine(StockHolding stockHolding)
        {
            _stockHolding = stockHolding;
        }

        private void ShowAllProductsAndPrices()
        {
            var productNum = 1;
            foreach (var drink in _stockHolding.Drinks)
            {
                Console.WriteLine($"{productNum.ToString().PadLeft(2, '0')}: {drink.Name} : {drink.Price}kr");
                productNum++;
            }
        }

        public int ProductPrice(int productNum)
        {
            var productIndex = productNum - 1;
            return _stockHolding.Drinks[productIndex].Price;
        }

        public string ProductName(int productNum)
        {
            var productIndex = productNum - 1;
            return _stockHolding.Drinks[productIndex].Name;
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----- BRUSAUTOMAT -----\n");
            ShowAllProductsAndPrices();
            Console.WriteLine($"\nPenger i brusmaskinen: {Cash}kr\n");
            ShowInstruction();
        }

        private void ShowInstruction()
        {
            Console.WriteLine("\n----- INSTRUKSJON -----\n");
            Console.WriteLine("- Skriv inn en gyldig kronemynt (1, 5, 10, 20) for å legge inn penger i brusmaskinen.");
            Console.WriteLine("- Skriv inn nummeret på produktet du vil kjøpe.");
            Console.WriteLine("- Skriv inn avslutt for å avslutte og få de resterende pengene tilbake.\n");
        }

        private void ReduceCash(int amount)
        {
            Cash -= amount;
        }

        public void RecieveCash(int amount)
        {
            Cash += amount;
        }

        public bool GotEnoughCashForDesiredProduct(int productNum)
        {
            return Cash - ProductPrice(productNum) >= 0 ? true : false;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void GiveProduct(int productNum)
        {
            var productPrice = ProductPrice(productNum);
            ReduceCash(productPrice);
        }
    }
}
