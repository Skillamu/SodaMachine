using System.Reflection.PortableExecutable;
using System.Security.Principal;

namespace SodaMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stockHolding = new StockHolding();
            var machine = new Machine(stockHolding);

            var depositCommand = new DepositCommand();
            var exitCommand = new ExitCommand();
            var buyCommand = new BuyCommand(stockHolding.Drinks.Length);    // Buy commands are automatically
                                                                            // added when a new type of
            var user = new User(depositCommand, exitCommand, buyCommand);   // drink is added to the soda machine.
                                                                            
            while (true)
            {
                machine.ShowMenu();
                user.ShowCash();
                user.SelectInput();

                while (!user.ValidCommand())
                {
                    machine.ShowMenu();
                    user.ShowCash();
                    user.SelectInput();
                }
                if (user.WantToDeposit())
                {
                    if (!user.HasEnoughCashToDepositDesiredValue())
                    {
                        machine.ShowMenu();
                        user.ShowCash();
                        machine.SendMessage("Du har ikke nok penger på konto...");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        user.DepositTo(machine);
                        machine.ShowMenu();
                        user.ShowCash();
                        var depositValue = user.Input;
                        machine.SendMessage($"Du la inn {depositValue}kr i brusmaskinen.");
                        Thread.Sleep(2000);
                    }
                }
                else if (user.WantToExit())
                {
                    user.RecieveRemainingCashFrom(machine);
                    machine.ShowMenu();
                    user.ShowCash();
                    machine.SendMessage($"Du fikk tilbake {machine.Cash}kr");
                    user.ShowCash();
                    machine.SendMessage("Ha en fin dag!");
                    Thread.Sleep(5000);
                    break;
                }
                else
                {
                    if (!machine.GotEnoughCashFrom(user))
                    {
                        machine.ShowMenu();
                        user.ShowCash();
                        machine.SendMessage("Det er ikke lagt inn nok penger i brusmaskinen for å kjøpe dette produktet...");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        var productNum = Convert.ToInt32(user.Input);
                        var productName = machine.ProductName(productNum);
                        var productPrice = machine.ProductPrice(productNum);

                        user.RecieveProductFrom(machine);
                        machine.ShowMenu();
                        user.ShowCash();
                        machine.SendMessage($"Du kjøpte en {productName} til {productPrice}kr.");
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}