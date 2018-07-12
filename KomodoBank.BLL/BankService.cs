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

        public Savings CreateSavingsAccountWithMinimumBalance(string nameInput, int idInput)
        {
            return new Savings(nameInput, idInput);
        }
        public Savings CreateSavingsAccount(string nameInput, decimal balanceInput, int idInput)
        {
            return new Savings(nameInput, balanceInput, idInput);
        }

        public Checking CreateCheckingAccount(string nameInput, decimal balanceInput, int idInput)
        {
            return new Checking(nameInput, balanceInput, idInput);
        }

        public void AddAccountToMasterList(Account customer)
        {
            _accountList.Add(customer);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountList;
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
            var contextedList = new List<Account>();

            if (_accountList != null)
            {
                foreach (var customer in _accountList)
                {
                    if (customer.LastName.Contains(searchInput))
                    {
                        contextedList.Add(customer);
                    }
                }
            }

            return contextedList;
        }
    }
}
