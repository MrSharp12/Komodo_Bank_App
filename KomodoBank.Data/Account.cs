using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public abstract class Account 
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        public string LastName { get; private set; }
        public int ID { get; private set; }

        public Account()
        {
        }

        protected Account(string lastName, int id)
        {
            LastName = lastName;
            ID = id;
        }

        protected Account(string lastName, decimal balance, int id)
        {
            LastName = lastName;
            Balance = balance;
            ID = id;
        }

        //public abstract void Withdraw(decimal withdrawAmount);
       public abstract decimal Deposit(decimal depositAmount);

        
    }
}
