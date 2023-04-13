using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class DepositCommand : Command
    {
        public override string[] GetCommands()
        {
            var validCommands = new[] { "20", "10", "5", "1" };
            return validCommands;
        }

        public bool IsValid(string command)
        {
            var depositCommands = GetCommands();
            return depositCommands.Contains(command) ? true : false;
        }
    }
}
