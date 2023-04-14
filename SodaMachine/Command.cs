using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract internal class Command
    {
        public abstract string[] ArrayOfValidCommands();

        public abstract bool IsValid(string input);
    }
}
