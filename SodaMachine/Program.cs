using System.Reflection.PortableExecutable;
using System.Security.Principal;

namespace SodaMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var machine = new Machine();

            var cmds = new Command[]
            {
                new DepositCommand(user, machine),
                new ExitCommand(user, machine),
                new BuyCommand(user, machine),
            };

            while (true)
            {
                Console.Clear();

                machine.ShowMenu();
                user.ShowCash();
                user.ChooseInput();

                var selectedCmd = cmds.SingleOrDefault(
                    cmd => cmd.Exists(user.ChosenCommand));

                selectedCmd?.Run();
            }
        }
    }
}