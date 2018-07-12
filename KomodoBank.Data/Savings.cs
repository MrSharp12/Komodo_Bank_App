using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public class Savings : Account
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 1000m)
                {
                    throw new ArgumentException("Savings account must have 1000 dollars");
                }
                else
                {
                    _balance = value;
                }
            }
        }

        public Savings(string lastName, decimal balance, int id) : base(lastName, balance, id)
        {
            Balance = balance;
        }
    }
}
