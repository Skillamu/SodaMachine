﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    internal class Account
    {
        public int Cash { get; private set; }

        public Account()
        {
            Cash = 100;
        }

        public void DecreaseCash(int amount)
        {
            Cash -= amount;
        }

        public void IncreaseCash(int amount)
        {
            Cash += amount;
        }
    }
}
