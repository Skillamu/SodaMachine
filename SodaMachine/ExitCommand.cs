using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class ExitCommand : Command
    {
        public override string[] ArrayOfValidCommands()
        {
            var validCommands = new[] { "avslutt" };
            return validCommands;
        }

        public override bool IsValid(string input)
        {
            var exitCommand = ArrayOfValidCommands();
            return exitCommand.Contains(input) ? true : false;
        }
    }
}
