using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract internal class Command
    {
        private string[] _commands;

        public Command(string[] commands)
        {
            _commands = commands;
        }

        public abstract void Run();

        public bool Exists(string cmdFromUser)
            => _commands.Any(cmd => cmd.Equals(cmdFromUser));
    }
}
