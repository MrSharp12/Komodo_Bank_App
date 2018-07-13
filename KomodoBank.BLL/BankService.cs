using KomodoBank.Contracts;
using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.BLL
{
    public class BankService
    {
        private List<Account> _accountList = new List<Account>();

        public void AddAccountToMasterList(Account customer)
        {
            _accountList.Add(customer);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountList;
        }
    }
}
