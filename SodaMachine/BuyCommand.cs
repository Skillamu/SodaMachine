using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class BuyCommand : Command
    {
        public int _stockHoldingDrinksLength;

        public BuyCommand(int stockHoldingDrinksLength)
        {
            _stockHoldingDrinksLength = stockHoldingDrinksLength;
        }

        public override string[] ArrayOfValidCommands()
        {
            var validCommands = new List<string>();

            for (int i = 0; i < _stockHoldingDrinksLength; i++)
            {
                validCommands.Add($"0{i + 1}");
            }

            return validCommands.ToArray();
        }

        public override bool IsValid(string input)
        {
            var buyCommands = ArrayOfValidCommands();
            return buyCommands.Contains(input) ? true : false;
        }
    }
}
