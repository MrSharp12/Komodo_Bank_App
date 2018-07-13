using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.BLL
{
    public class CheckingRepo
    {
        private List<Checking> _checkingAccountList = new List<Checking>();

        public Checking CreateCheckingAccount(string nameInput, decimal balanceInput, int idInput)
        {
            return new Checking(nameInput, balanceInput, idInput);
        }

        public void AddAccountToCheckingList(Checking customer)
        {
            _checkingAccountList.Add(customer);
        }

        public List<Checking> GetAllCheckingAccounts()
        {
            return _checkingAccountList;
        }
    }
}
