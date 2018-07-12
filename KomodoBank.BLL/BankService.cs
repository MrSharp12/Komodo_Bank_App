using KomodoBank.Contracts;
using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.BLL
{
    public class BankService : IMaster
    {
        private List<Account> _accountList = new List<Account>();

        public List<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetCheckingAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetSavingsAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> Search(string searchInput)
        {
            throw new NotImplementedException();
        }
    }
}
