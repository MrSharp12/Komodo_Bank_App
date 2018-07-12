using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Data
{
    public class Checking : Account
    {
        public Checking(string lastName, decimal balance, int id) : base(lastName, balance, id)
        {
        }
    }
}
