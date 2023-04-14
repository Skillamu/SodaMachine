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
                    user.DepositTo(machine);
                }
                else if (user.WantToExit())
                {
                    user.ExitFrom(machine);
                    break;
                }
                else
                {
                    user.BuyProductFrom(machine);
                }
            }
        }
    }
}