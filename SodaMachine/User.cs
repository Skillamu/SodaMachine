using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class User
    {
        public string Input { get; private set; }
        public int Cash { get; private set; }
        private DepositCommand _depositCommand;
        private ExitCommand _exitCommand;
        private BuyCommand _buyCommand;

        public User(DepositCommand depositCommand, ExitCommand exitCommand, BuyCommand buyCommand)
        {
            Cash = 100;
            _depositCommand = depositCommand;
            _exitCommand = exitCommand;
            _buyCommand = buyCommand;
        }

        private void ReduceCash(int amount)
        {
            Cash -= amount;
        }

        private void RecieveCash(int amount)
        {
            Cash += amount;
        }

        public void ShowCash()
        {
            Console.WriteLine($"\nDin saldo: {Cash}kr\n");
        }

        public bool WantToDeposit()
        {
            return _depositCommand.IsValid(Input) ? true : false;
        }

        public bool WantToExit()
        {
            return _exitCommand.IsValid(Input) ? true : false;
        }

        public void SelectInput()
        {
            Input = Console.ReadLine();
        }

        public bool ValidCommand()
        {
            return _depositCommand.IsValid(Input) ? true :
                      _exitCommand.IsValid(Input) ? true :
                       _buyCommand.IsValid(Input) ? true : false;
        }

        public void DepositTo(Machine machine)
        {
            var depositValue = Convert.ToInt32(Input);
            machine.RecieveCash(depositValue);
            ReduceCash(depositValue);
        }

        public bool HasEnoughCashToDepositDesiredValue()
        {
            var depositValue = Convert.ToInt32(Input);
            return Cash - depositValue >= 0 ? true : false;
        }

        public void RecieveProductFrom(Machine machine)
        {
            var productNum = Convert.ToInt32(Input);
            machine.GiveProduct(productNum);
        }

        public void RecieveRemainingCashFrom(Machine machine)
        {
            RecieveCash(machine.Cash);
        }
    }
}
