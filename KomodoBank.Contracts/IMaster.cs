using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Contracts
{
    public interface IMaster
    {
        List<Account> GetAllAccounts();
        List<Account> Search(string searchInput);
        List<Account> GetCheckingAccounts();
        List<Account> GetSavingsAccounts();
    }
}
