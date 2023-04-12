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
        private StockHolding _stockHolding;
        public int Cash { get; private set; }
        public int CurrentDisplay { get; private set; }

        public Machine(StockHolding stockHolding)
        {
            _stockHolding = stockHolding;
            CurrentDisplay = 1;
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

        public int GetPriceOfProduct(int index)
        {
            return _stockHolding.Drinks[index].Price;
        }

        public string GetNameOfProduct(int index)
        {
            return _stockHolding.Drinks[index].Name;
        }

        /*public void ReduceQuantityOfProduct(int index)
        {
            Drinks[index].ReduceQuantity();
            Console.WriteLine($"Antall igjen: {Drinks[index].Quantity}");
        }*/

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----- BRUSAUTOMAT -----\n");
            ShowAllProductsAndPrices();
            Console.WriteLine($"\nPenger i brusmaskinen: {Cash}kr\n");
            ShowInstruction();
        }

        public void ShowInstruction()
        {
            if (CurrentDisplay == 1)
            {
                Console.WriteLine("\n----- DISPLAY 1 -----\n");
                Console.WriteLine("Skriv inn en kronemynt (1, 5, 10, 20) for å legge inn penger i brusmaskinen.");
                Console.WriteLine("Skriv inn display2 for å bytte til skjermen der du velger og kjøper drikke.");
            }
            else
            {
                Console.WriteLine("\n----- DISPLAY 2 -----\n");
                Console.WriteLine("Skriv inn nummeret til produktet du vil kjøpe.");
                Console.WriteLine("Skriv inn display1 for å bytte til skjermen der du legger inn penger i brusmaskinen.");
                Console.WriteLine("Skriv inn avslutt for å avslutte og få de resterende pengene tilbake.\n");
            }
        }

        public void DecreaseCash(int amount)
        {
            Cash -= amount;
        }

        public void IncreaseCash(int amount)
        {
            Cash += amount;
        }

        public bool ValidInput(string input)
        {
            var validInputs = GetArrayOfValidInputsForCurrentDisplay();

            return validInputs.Contains(input) ? true : false;
        }

        private string[] GetArrayOfValidInputsForCurrentDisplay()
        {
            if (CurrentDisplay == 1)
            {
                var validInputs = new[] { "20", "10", "5", "1", "display2" };

                return validInputs;
            }
            else
            {
                var validInputs = new List<string>();

                for (int i = 0; i < _stockHolding.Drinks.Length; i++)
                {
                    validInputs.Add($"0{i + 1}");
                }
                validInputs.Add("display1");
                validInputs.Add("avslutt");

                return validInputs.ToArray();
            }
        }

        public void ChangeDisplay()
        {
            CurrentDisplay = CurrentDisplay == 1 ? 2 : 1;
        }
    }
}
