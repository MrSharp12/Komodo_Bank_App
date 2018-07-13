using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public abstract class Account 
    {
        public decimal Balance { get; private set; }
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
    }
}
