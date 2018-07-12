using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public class Checking : Account
    {
        public decimal Balance { get; private set; }

        public Checking(string lastName, decimal balance, int id)
        {
            Balance = balance;
        }

        public override decimal Deposit(decimal depositAmount)
        {
            return Balance += depositAmount;
        }

        public override void Withdraw(decimal withdrawAmount)
        {
            var balanceTotal = Balance -= withdrawAmount;
            if (balanceTotal < 0)
            {
                throw new ArgumentException("Insufficient funds");
            }
            else
            {
                Balance = balanceTotal;
            }
        }

        public void Transfer(decimal transferAmount, Savings savingsAccount)
        {
            var balanceTotal = Balance -= transferAmount;
            if (balanceTotal < 0)
            {
                throw new ArgumentException("Insufficient funds");
            }
            else
            {
                savingsAccount.Deposit(transferAmount);
            }
        }
    }
}
