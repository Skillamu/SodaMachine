using System.Reflection.PortableExecutable;

namespace SodaMachine
{
    internal class Program
    {
        private static int _currentDisplay = 1;
        private static int _machineBalance = 0;
        private static int _accountBalance = 100;

        static void Main(string[] args)
        {
            while (true)
            {
                if (_currentDisplay == 1)
                {
                    DisplayOne();
                    var input = Console.ReadLine();
                    while (input != "20" && input != "10" && input != "5" && input != "1" && input != "display2")
                    {
                        DisplayOne();
                        input = Console.ReadLine();
                    }
                    if (input == "display2")
                    {
                        _currentDisplay = 2;
                    }
                    else
                    {
                        var deposit = Convert.ToInt32(input);
                        if ((_accountBalance - deposit) < 0)
                        {
                            DisplayOne();
                            Console.WriteLine("Du har ikke nok penger på konto...");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            _machineBalance += deposit;
                            _accountBalance -= deposit;
                            DisplayOne();
                        }
                    }
                }
                if (_currentDisplay == 2)
                {
                    DisplayTwo();
                    var input = Console.ReadLine();
                    while (input != "01" && input != "02" && input != "03" && input != "display1")
                    {
                        DisplayTwo();
                        input = Console.ReadLine();
                    }
                    if (input == "display1")
                    {
                        _currentDisplay = 1;
                    }
                    else
                    {
                        var stockHolding = new StockHolding();
                        var productNum = Convert.ToInt32(input);
                        var productIndex = (productNum - 1);
                        if (_machineBalance - stockHolding.GetPriceOfProduct(productIndex) < 0)
                        {
                            DisplayTwo();
                            Console.WriteLine("Det er ikke lagt inn nok penger i maskinen for å kjøpe dette produktet...");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            // Legge til logikk her
                        }
                    }
                }
            }
        }

        static void DisplayOne()
        {
            Console.Clear();
            Console.WriteLine("DISPLAY 1\n");
            Console.WriteLine($"Din saldo: {_accountBalance}kr\n");
            Console.WriteLine($"Antall penger i brusmaskinen: {_machineBalance}kr\n");
            Console.WriteLine("Skriv inn en kronemynt (1, 5, 10, 20) for å legge inn penger i brusmaskinen.");
            Console.WriteLine("Skriv inn display2 for å bytte til menyen der du kan kjøpe drikke.");
        }

        static void DisplayTwo()
        {
            var stockHolding = new StockHolding();
            Console.Clear();
            Console.WriteLine("DISPLAY 2\n");
            stockHolding.ShowAllProductsAndPrices();
            Console.WriteLine($"Din saldo: {_accountBalance}kr\n");
            Console.WriteLine($"Antall penger i brusmaskinen: {_machineBalance}kr\n");
            Console.WriteLine("Skriv inn nummeret til produktet du vil kjøpe.");
            Console.WriteLine("Skriv inn display1 for å bytte til menyen der du setter inn penger");
        }
    }
}