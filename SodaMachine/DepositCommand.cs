using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class DepositCommand : Command
    {
        private User _user;
        private Machine _machine;

        public DepositCommand(User user, Machine machine)
            : base(new string[] { "20", "10", "5", "1" })
        {
            _user = user;
            _machine = machine;
        }

        public override void Run()
        {
            _machine.ShowMenu();
            _user.ShowCash();

            _user.DepositTo(_machine);
            Thread.Sleep(2000);
        }
    }
}
