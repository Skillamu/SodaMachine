using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class ExitCommand : Command
    {
        private User _user;
        private Machine _machine;

        public ExitCommand(User user, Machine machine)
            : base(new string[] { "avslutt" })
        {
            _user = user;
            _machine = machine;
        }

        public override void Run()
        {
            _machine.ShowMenu();
            _user.ShowCash();

            _user.ExitFrom(_machine);
        }
    }
}
