using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public class Savings : Account
    {
        public decimal Balance { get; private set; } = 300m;

        public Savings() 
        {
            
        }

        public Savings(string lastName, int id)
        {

        }

        public Savings(string lastName, decimal balance, int id)
        {
            Balance = balance;
        }

        public override void Withdraw(decimal withdrawAmount)
        {
            var balanceTotal = Balance -= withdrawAmount;
            if (balanceTotal < 0)
            {
                throw new ArgumentException("Insufficient funds");
            }
            else if (withdrawAmount >= 10000m)
            {
                throw new ArgumentException("You may not remove funds greater than or equal to 10,000 dollars in one transaction");
            }
            else
            {
                Balance = balanceTotal;
            }
        }

        public override decimal Deposit(decimal depositAmount)
        {
            return Balance += depositAmount;
        }

        public void Transfer(decimal transferAmount, Checking checkingAccount)
        {
            var balanceTotal = Balance -= transferAmount;
            if (balanceTotal < 0)
            {
                throw new ArgumentException("Insufficient funds");
            }
            else
            {
                checkingAccount.Deposit(transferAmount);
            }
        }
    }
}
