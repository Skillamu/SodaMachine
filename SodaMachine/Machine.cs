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
        private Drink[] _drinks;

        public Machine()
        {
            _drinks = new Drink[]
            {
                new Drink("Coca Cola", 20),
                new Drink("Fanta", 5),
                new Drink("Villa", 10),
                new Drink("Pepsi", 30),
                new Drink("Solo", 50),
            };
        }

        private void ShowAllProductsAndPrices()
        {
            var productNum = 1;
            foreach (var drink in _drinks)
            {
                Console.WriteLine($"{productNum.ToString().PadLeft(2, '0')}: {drink.Name} : {drink.Price}kr");
                productNum++;
            }
        }

        public int ProductPrice(int productNum)
        {
            var productIndex = productNum - 1;
            return _drinks[productIndex].Price;
        }

        public string ProductName(int productNum)
        {
            var productIndex = productNum - 1;
            return _drinks[productIndex].Name;
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----- BRUSAUTOMAT -----\n");
            ShowAllProductsAndPrices();
            Console.WriteLine($"\nPenger i brusautomaten: {Cash}kr\n");
            ShowInstruction();
        }

        private void ShowInstruction()
        {
            Console.WriteLine("\n----- INSTRUKSJON -----\n");
            Console.WriteLine("- Skriv inn en gyldig kronemynt (1, 5, 10, 20) for å legge inn penger i brusautomaten.");
            Console.WriteLine("- Skriv inn nummeret på produktet du vil kjøpe.");
            Console.WriteLine("- Skriv inn avslutt for å avslutte og få de resterende pengene tilbake.\n");
        }

        private void ReduceCash(int amount) 
            => Cash -= amount;

        public void RecieveCash(int amount) 
            => Cash += amount;

        public bool GotEnoughCashForDesiredProduct(int productNum)
            => Cash - ProductPrice(productNum) >= 0 ? true : false;

        public void SendMessage(string message) 
            => Console.WriteLine(message);

        public void GiveProduct(int productNum)
        {
            var productPrice = ProductPrice(productNum);
            ReduceCash(productPrice);
        }
    }
}
