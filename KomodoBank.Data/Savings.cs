﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public class Savings : Account
    {
        public decimal Balance { get; private set; } = 300m;
        public string LastName { get; private set; }
        public int ID { get; private set; }

        public Savings()
        {
        }

        public Savings(string lastName, int id) : base(lastName, id)
        {
            LastName = lastName;
            ID = id;
        }

        public Savings(string lastName, decimal balance, int id) : base(lastName, balance, id)
        {
            LastName = lastName;
            Balance = balance;
            ID = id;
        }

        public decimal Deposit(decimal depositAmount)
        {
            return Balance += depositAmount;
        }
        public void Withdraw(decimal withdrawAmount)
        {
            var balanceTotal = Balance -= withdrawAmount;
            if (balanceTotal < 0)
            {
                throw new Exception("Insufficient funds");
            }

            if (withdrawAmount >= 10000m)
            {
                throw new ArgumentException("You may not remove funds greater than or equal to 10,000 dollars in one transaction");
            }

            Balance = balanceTotal;

        }

        public void Transfer(decimal transferAmount, Checking checkingAccount)
        {
            var balanceTotal = Balance -= transferAmount;
            if (balanceTotal < 0)
            {
                throw new ArgumentException("Insufficient funds");
            }

            checkingAccount.Deposit(transferAmount);
            Balance = balanceTotal;

        }
    }
}
