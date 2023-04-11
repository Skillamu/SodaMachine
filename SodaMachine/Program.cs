using System.Reflection.PortableExecutable;

namespace SodaMachine
{
    internal class Program
    {
        private static int _currentDisplay = 1;
        private static int _machineBalance = 0;
        private static int _accountBalance = 100;
        private static Machine _machine = new Machine();

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
                            Console.WriteLine("\nDu har ikke nok penger på konto...");
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
                    while (input != "01" && input != "02" && input != "03" && input != "display1" && input != "avslutt")
                    {
                        DisplayTwo();
                        input = Console.ReadLine();
                    }
                    if (input == "display1")
                    {
                        _currentDisplay = 1;
                    }
                    else if (input == "avslutt")
                    {
                        _accountBalance += _machineBalance;
                        Console.WriteLine($"\nDu fikk tilbake {_machineBalance}kr.");
                        Console.WriteLine($"Din saldo: {_accountBalance}kr.");
                        Console.WriteLine("\nHa en fin dag!");
                        Thread.Sleep(5000);
                        break;
                    }
                    else
                    {
                        var productNum = Convert.ToInt32(input);
                        var productIndex = (productNum - 1);
                        if (_machineBalance - _machine.GetPriceOfProduct(productIndex) < 0)
                        {
                            DisplayTwo();
                            Console.WriteLine("\nDet er ikke lagt inn nok penger i maskinen for å kjøpe dette produktet...");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            _machineBalance -= _machine.GetPriceOfProduct(productIndex);
                            DisplayTwo();

                            var productName = _machine.GetNameOfProduct(productIndex);
                            var productPrice = _machine.GetPriceOfProduct(productIndex);
                            Console.WriteLine($"\nDu kjøpte en {productName} til {productPrice}kr.");
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
        }

        static void DisplayOne()
        {
            Console.Clear();
            Console.WriteLine("--- BRUSAUTOMAT ---\n");
            _machine.ShowAllProductsAndPrices();
            Console.WriteLine($"\nPenger i brusmaskinen: {_machineBalance}kr");
            Console.WriteLine($"Din saldo: {_accountBalance}kr\n");
            Console.WriteLine("Skriv inn en kronemynt (1, 5, 10, 20) for å legge til penger i brusmaskinen.");
            Console.WriteLine("Skriv inn display2 for å bytte til skjermen der du velger og kjøper drikke.");
        }

        static void DisplayTwo()
        {
            Console.Clear();
            Console.WriteLine("--- BRUSAUTOMAT ---\n");
            _machine.ShowAllProductsAndPrices();
            Console.WriteLine($"\nPenger i brusmaskinen: {_machineBalance}kr\n");
            Console.WriteLine("Skriv inn nummeret til produktet du vil kjøpe.");
            Console.WriteLine("Skriv inn display1 for å bytte til skjermen der du legger inn penger i brusmaskinen.");
            Console.WriteLine("Skriv inn avslutt for å avslutte og få de resterende pengene tilbake.");
        }
    }
}