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

        public List<Account> Search(int searchInput)
        {
            var contextedList = new List<Account>();

            foreach (var customer in _accountList)
            {
                if (customer.ID == searchInput)
                {
                    contextedList.Add(customer);
                }
            }
            
            return contextedList;
        }
    }
}
