using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class User
    {
        private int _cash;
        public string ChosenCommand { get; private set; }

        public User()
        {
            _cash = 100;
        }

        private void ReduceCash(int amount) 
            => _cash -= amount;

        private void RecieveCash(int amount) 
            => _cash += amount;

        public void ShowCash()
            => Console.WriteLine($"\nDin saldo: {_cash}kr\n");

        public void ChooseInput() 
            => ChosenCommand = Console.ReadLine();

        public void DepositTo(Machine machine)
        {
            var depositValue = Convert.ToInt32(ChosenCommand);

            if (!HasEnoughCashToDepositDesiredValue())
            {
                machine.SendMessage("Du har ikke nok penger på konto...");
            }
            else
            {
                ReduceCash(depositValue);
                machine.RecieveCash(depositValue);
                machine.SendMessage($"Du la inn {depositValue}kr i brusautomaten.");
            }
        }

        public void ExitFrom(Machine machine)
        {
            RecieveRemainingCashFrom(machine);
            machine.SendMessage($"Du fikk tilbake {machine.Cash}kr");
            machine.SendMessage("Ha en fin dag!");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        public void BuyProductFrom(Machine machine)
        {
            var productNum = Convert.ToInt32(ChosenCommand);

            if (!machine.GotEnoughCashForDesiredProduct(productNum))
            {
                machine.SendMessage("Det er ikke lagt inn nok penger i" +
                                    " brusautomaten for å kjøpe dette produktet...");
            }
            else
            {
                var productName = machine.ProductName(productNum);
                var productPrice = machine.ProductPrice(productNum);

                RecieveProductFrom(machine);
                machine.SendMessage($"Du kjøpte en {productName} til {productPrice}kr.");
            }
        }

        private bool HasEnoughCashToDepositDesiredValue()
        {
            var depositValue = Convert.ToInt32(ChosenCommand);
            return _cash - depositValue >= 0 ? true : false;
        }

        private void RecieveProductFrom(Machine machine)
        {
            var productNum = Convert.ToInt32(ChosenCommand);
            machine.GiveProduct(productNum);
        }

        private void RecieveRemainingCashFrom(Machine machine) 
            => RecieveCash(machine.Cash);
    }
}
