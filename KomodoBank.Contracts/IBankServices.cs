using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Contracts
{
    public interface IBankServices
    {
        Account CreateAccount(string lastName, decimal balance, int id);
        decimal Deposit(decimal depositAmount);
        decimal Withdraw(decimal withdrawAmount);
        decimal Transfer(decimal transferAmount);
    }
}
