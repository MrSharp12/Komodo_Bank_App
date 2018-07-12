using KomodoBank.BLL;
using KomodoBank.Contracts;
using KomodoBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBankUI
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        public BankService BankService;
        public Savings Savings;

        public ProgramUI(IConsole consoleForAllReadsAndWrites)
        {
            _console = consoleForAllReadsAndWrites;
            BankService = new BankService();
            Savings = new Savings();
        }

        public void Run()
        {
            bool finished = false;

            do
            {
                _console.WriteLine("What would you like to do?\r\n " +
                                   "1. Create an account\r\n " +
                                   "2. Deposit\r\n " +
                                   "3. Withdraw\r\n " +
                                   "4. Transfer\r\n " +
                                   "5. View all accounts\r\n " +
                                   "6. View all checking accounts\r\n " +
                                   "7. View all savings accounts\r\n " +
                                   "8. Find specific account\r\n " +
                                   "9. Exit program\r\n ");

                var command = _console.ReadLine().ToLower();

                if (String.IsNullOrWhiteSpace(command))
                {
                    finished = true;
                }
                else if (command == "1")
                {
                    CreateNewAccount();
                }
                else if (command == "2")
                {
                    Deposit();
                }
                else if (command == "3")
                {
                    _console.WriteLine("3");
                }
                else if (command == "4")
                {
                    _console.WriteLine("4");
                }
                else if (command == "5")
                {
                    SeeAllAccounts();
                }
                else if (command == "6")
                {
                    _console.WriteLine("6");
                }
                else if (command == "7")
                {
                    _console.WriteLine("7");
                }
                else if (command == "8")
                {
                    _console.WriteLine("8");
                }
                else if (command == "9")
                {
                    finished = true;
                }
                else
                {
                    _console.WriteLine("Please enter a valid number");
                }
            } while (!finished);
        }

        public void CreateNewAccount()
        {
            _console.WriteLine("What account do you want to create? \r\n " +
                                "1. Savings \r\n " +
                                "2. Checking \r\n");

            var command = _console.ReadLine();

            if (command == "1")
            {
                _console.WriteLine("Create account with minimum balance? (Y/N)");
                var savingTypeCommand = _console.ReadLine().ToUpper();

                if (savingTypeCommand == "Y")
                {
                    _console.WriteLine("Enter last name:");
                    var nameInput = _console.ReadLine();

                    _console.WriteLine("Enter ID:");
                    var idInput = Convert.ToInt32(_console.ReadLine());

                    var newSavingsAccount = BankService.CreateSavingsAccountWithMinimumBalance(nameInput, idInput);
                    BankService.AddAccountToMasterList(newSavingsAccount);
                    _console.WriteLine("Account created");

                }
                else if (savingTypeCommand == "N")
                {
                    _console.WriteLine("Enter last name:");
                    var nameInput = _console.ReadLine();

                    _console.WriteLine("Enter balance:");
                    var balanceInput = Convert.ToDecimal(_console.ReadLine());

                    _console.WriteLine("Enter ID:");
                    var idInput = Convert.ToInt32(_console.ReadLine());

                    var newSavingsAccount = BankService.CreateSavingsAccount(nameInput, balanceInput, idInput);
                    BankService.AddAccountToMasterList(newSavingsAccount);
                    _console.WriteLine("Account created");
                }
                else
                {
                    _console.WriteLine("Please enter a valid option");
                }
            }
            else if (command == "2")
            {
                _console.WriteLine("Enter last name:");
                var nameInput = _console.ReadLine();

                _console.WriteLine("Enter balance:");
                var balanceInput = Convert.ToDecimal(_console.ReadLine());

                _console.WriteLine("Enter ID:");
                var idInput = Convert.ToInt32(_console.ReadLine());

                var newCheckingAccount = BankService.CreateCheckingAccount(nameInput, balanceInput, idInput);
                BankService.AddAccountToMasterList(newCheckingAccount);
                _console.WriteLine("Account created");
            }
        }

        public void Deposit()
        {
            _console.WriteLine("Please select account to deposit funds:");
            var accountInput = Convert.ToInt32(_console.ReadLine());

            _console.WriteLine("Amount to deposit:");
            var depositAmount = Convert.ToDecimal(_console.ReadLine());

            foreach (var customer in BankService.GetAllAccounts())
            {
                if (customer.ID == accountInput && customer is Savings)
                {
                    customer.Deposit(depositAmount);
                }
            }

            

            //Savings.Deposit(accountInput, depositAmount);
        }

        public void SeeAllAccounts()
        {
            if (BankService.GetAllAccounts().Count > 0)
            {
                _console.WriteLine("Displaying all accounts");

                foreach (var customer in BankService.GetAllAccounts())
                {
                    _console.WriteLine($"Last Name: {customer.LastName}\n" +
                                       $"ID: {customer.ID}\n" +
                                       $"Balance: {customer.Balance}\n");
                }
            }
            else
            {
                _console.WriteLine("The list is empty");
            }
        }

    }


}
