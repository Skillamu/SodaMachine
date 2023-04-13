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

        public override string[] GetCommands()
        {
            var validCommands = new List<string>();

            for (int i = 0; i < _stockHoldingDrinksLength; i++)
            {
                validCommands.Add($"0{i + 1}");
            }

            return validCommands.ToArray();
        }

        public bool IsValid(string command)
        {
            var buyCommands = GetCommands();
            return buyCommands.Contains(command) ? true : false;
        }
    }
}
