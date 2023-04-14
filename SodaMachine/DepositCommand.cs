using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class DepositCommand : Command
    {
        public override string[] ArrayOfValidCommands()
        {
            var validCommands = new[] { "20", "10", "5", "1" };
            return validCommands;
        }

        public override bool IsValid(string input)
        {
            var depositCommands = ArrayOfValidCommands();
            return depositCommands.Contains(input) ? true : false;
        }
    }
}
