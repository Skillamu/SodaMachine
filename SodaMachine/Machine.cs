﻿using System;
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
            Console.WriteLine("\n----- INSTRUKSJON -----\n");
            Console.WriteLine("- Skriv inn en kronemynt (1, 5, 10, 20) for å legge inn penger i brusmaskinen.");
            Console.WriteLine("- Skriv inn nummeret på produktet du vil kjøpe.");
            Console.WriteLine("- Skriv inn avslutt for å avslutte og få de resterende pengene tilbake.\n");
        }

        public void DecreaseCash(int amount)
        {
            Cash -= amount;
        }

        public void IncreaseCash(int amount)
        {
            Cash += amount;
        }

        /*public bool ValidInput(string input)
        {
            var validInputs = GetArrayOfValidInputsForCurrentDisplay();

            return validInputs.Contains(input) ? true : false;
        }

        private string[] GetArrayOfValidInputsForCurrentDisplay()
        {
            var validInputs = new List<string>()
            {
                "20",
                "10",
                "5",
                "1",
                "avslutt",
            };

            for (int i = 0; i < _stockHolding.Drinks.Length; i++)
            {
                validInputs.Add($"0{i + 1}");
            }

            return validInputs.ToArray();
        }*/
    }
}
