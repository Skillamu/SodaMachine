using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class ExitCommand : Command
    {
        public override string[] GetCommands()
        {
            var validCommands = new[] { "avslutt" };
            return validCommands;
        }

        public bool IsValid(string command)
        {
            var exitCommand = GetCommands();
            return exitCommand.Contains(command) ? true : false;
        }
    }
}
