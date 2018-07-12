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
            set { _balance = value; }
        }

        public string LastName { get; private set; }
        public int ID { get; private set; }

        protected Account(string lastName, decimal balance, int id)
        {
            LastName = lastName;
            Balance = balance;
            ID = id;
        }
    }
}
