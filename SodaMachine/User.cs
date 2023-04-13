using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class User
    {
        public string _input;
        public int Cash { get; private set; }
        public DepositCommand _depositCommand;
        public ExitCommand _exitCommand;
        public BuyCommand _buyCommand;

        public User(DepositCommand depositCommand, ExitCommand exitCommand, BuyCommand buyCommand)
        {
            Cash = 100;
            _depositCommand = depositCommand;
            _exitCommand = exitCommand;
            _buyCommand = buyCommand;
        }

        public void DecreaseCash(int amount)
        {
            Cash -= amount;
        }

        public void IncreaseCash(int amount)
        {
            Cash += amount;
        }

        public void ShowCash()
        {
            Console.WriteLine($"\nDin saldo: {Cash}kr\n");
        }

        public bool WantToDeposit()
        {
            return _depositCommand.IsValid(_input) ? true : false;
        }

        public bool WantToExit()
        {
            return _exitCommand.IsValid(_input) ? true : false;
        }

        public string Input()
        {
            _input = Console.ReadLine();
            return _input;
        }

        public bool ValidCommand()
        {
            return _depositCommand.IsValid(_input) ? true :
                      _exitCommand.IsValid(_input) ? true :
                       _buyCommand.IsValid(_input) ? true : false;



        }
    }
}
