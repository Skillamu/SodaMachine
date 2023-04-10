using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class Account
    {
        public int Balance { get; private set; }

        public Account()
        {
            Balance = 100;
        }

        public void ReduceBalance(int amount)
        {
            Balance -= amount;
        }

        public void IncreaseBalance(int amount)
        {
            Balance += amount;
        }

        public int Deposit()
        {
            var deposit = Convert.ToInt32(Console.ReadLine());
            return deposit;
        }
    }
}
