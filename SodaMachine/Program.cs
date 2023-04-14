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
                    var depositValue = Convert.ToInt32(user.Input);

                    if ((user.Cash - depositValue) < 0)
                    {
                        machine.ShowMenu();
                        user.ShowCash();
                        Console.WriteLine("Du har ikke nok penger på konto...");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        machine.RecieveCash(depositValue);
                        user.ReduceCash(depositValue);
                        machine.ShowMenu();
                        user.ShowCash();
                        Console.WriteLine($"Du la inn {depositValue}kr i brusmaskinen.");
                        Thread.Sleep(2000);
                    }
                }
                else if (user.WantToExit())
                {
                    machine.ShowMenu();
                    user.ShowCash();
                    user.RecieveCash(machine.Cash);
                    Console.WriteLine($"Du fikk tilbake {machine.Cash}kr");
                    user.ShowCash();
                    Console.WriteLine("Ha en fin dag!");
                    Thread.Sleep(5000);
                    break;
                }
                else
                {
                    var productNum = Convert.ToInt32(user.Input);
                    var productIndex = (productNum - 1);

                    if (machine.Cash - machine.GetPriceOfProduct(productIndex) < 0)
                    {
                        machine.ShowMenu();
                        user.ShowCash();
                        Console.WriteLine("Det er ikke lagt inn nok penger i brusmaskinen for å kjøpe dette produktet...");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        var productName = machine.GetNameOfProduct(productIndex);
                        var productPrice = machine.GetPriceOfProduct(productIndex);

                        machine.ReduceCash(productPrice);
                        machine.ShowMenu();
                        user.ShowCash();
                        Console.WriteLine($"Du kjøpte en {productName} til {productPrice}kr.");
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}