using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class BuyCommand : Command
    {
        private User _user;
        private Machine _machine;

        public BuyCommand(User user, Machine machine)
            : base("01", "02", "03", "04", "05")
        {
            _user = user;
            _machine = machine;
        }

        public override void Run()
        {
            _machine.ShowMenu();
            _user.ShowCash();

            _user.BuyProductFrom(_machine);
            Thread.Sleep(2000);
        }
    }
}
