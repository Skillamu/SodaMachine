using System.Reflection.PortableExecutable;

namespace SodaMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            var stockHolding = new StockHolding();
            var machine = new Machine(stockHolding);

            while (true)
            {
                if (machine.CurrentDisplay == 1)
                {
                    machine.ShowMenu();
                    machine.ShowInstruction();
                    Console.WriteLine($"\nDin saldo: {account.Cash}kr\n");
                    var input = Console.ReadLine();

                    while (!machine.ValidInput(input))
                    {
                        machine.ShowMenu();
                        machine.ShowInstruction();
                        Console.WriteLine($"\nDin saldo: {account.Cash}kr\n");
                        input = Console.ReadLine();
                    }
                    if (input == "display2")
                    {
                        machine.ChangeDisplay();
                    }
                    else
                    {
                        var depositValue = Convert.ToInt32(input);

                        if ((account.Cash - depositValue) < 0)
                        {
                            machine.ShowMenu();
                            machine.ShowInstruction();
                            Console.WriteLine($"\nDin saldo: {account.Cash}kr\n");
                            Console.WriteLine("\nDu har ikke nok penger på konto...");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            stockHolding.IncreaseCash(depositValue);
                            account.DecreaseCash(depositValue);

                            machine.ShowMenu();
                            machine.ShowInstruction();
                            Console.WriteLine($"\nDin saldo: {account.Cash}kr\n");
                        }
                    }
                }
                if (machine.CurrentDisplay == 2)
                {
                    machine.ShowMenu();
                    machine.ShowInstruction();
                    var input = Console.ReadLine();

                    while (!machine.ValidInput(input))
                    {
                        machine.ShowMenu();
                        machine.ShowInstruction();
                        input = Console.ReadLine();
                    }
                    if (input == "display1")
                    {
                        machine.ChangeDisplay();
                    }
                    else if (input == "avslutt")
                    {
                        account.IncreaseCash(stockHolding.Cash);

                        Console.WriteLine($"\nDu fikk tilbake {stockHolding.Cash}kr");
                        Console.WriteLine($"Din saldo: {account.Cash}kr");
                        Console.WriteLine("\nHa en fin dag!");
                        Thread.Sleep(5000);
                        break;
                    }
                    else
                    {
                        var productNum = Convert.ToInt32(input);
                        var productIndex = (productNum - 1);

                        if (stockHolding.Cash - machine.GetPriceOfProduct(productIndex) < 0)
                        {
                            machine.ShowMenu();
                            machine.ShowInstruction();
                            Console.WriteLine("\nDet er ikke lagt inn nok penger i maskinen for å kjøpe dette produktet...");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            var productName = machine.GetNameOfProduct(productIndex);
                            var productPrice = machine.GetPriceOfProduct(productIndex);

                            stockHolding.DecreaseCash(productPrice);

                            machine.ShowMenu();
                            machine.ShowInstruction();

                            Console.WriteLine($"\nDu kjøpte en {productName} til {productPrice}kr.");
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
        }
    }
}