using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.BLL
{
    public class SavingsRepo
    {
        private List<Savings> _savingsAccountList = new List<Savings>();

        public Savings CreateSavingsAccountWithMinimumBalance(string nameInput, int idInput)
        {
            return new Savings(nameInput, idInput);
        }
        public Savings CreateSavingsAccount(string nameInput, decimal balanceInput, int idInput)
        {
            if (balanceInput < 300m)
            {
                throw new ArgumentException("Account must have 300 dollars to open");
            }
            return new Savings(nameInput, balanceInput, idInput);
        }

        public void AddAccountToSavingsList(Savings customer)
        {
            _savingsAccountList.Add(customer);
        }

        public List<Savings> GetAllSavingsAccounts()
        {
            return _savingsAccountList;
        }
        public bool ValidateSavingsAccount(int accountInput)
        {
            bool value;
            if (_savingsAccountList.Exists(account => account.ID == accountInput))
            {
                value = true;
            }
            else
            {
                value = false;
            }
            return value;
        }
    }
}
