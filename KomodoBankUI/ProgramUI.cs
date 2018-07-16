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
        public SavingsRepo SavingsRepo;
        public CheckingRepo CheckingRepo;

        public ProgramUI(IConsole consoleForAllReadsAndWrites)
        {
            _console = consoleForAllReadsAndWrites;
            BankService = new BankService();
            SavingsRepo = new SavingsRepo();
            CheckingRepo = new CheckingRepo();
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
                    Withdraw();
                }
                else if (command == "4")
                {
                    Transfer();
                }
                else if (command == "5")
                {
                    SeeAllAccounts();
                }
                else if (command == "6")
                {
                    SeeAllCheckingAccounts();
                }
                else if (command == "7")
                {
                    SeeAllSavingsAccounts();
                }
                else if (command == "8")
                {
                    Search();
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

                    var newSavingsAccount = SavingsRepo.CreateSavingsAccountWithMinimumBalance(nameInput, idInput);
                    BankService.AddAccountToMasterList(newSavingsAccount);
                    SavingsRepo.AddAccountToSavingsList(newSavingsAccount);
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

                    var newSavingsAccount = SavingsRepo.CreateSavingsAccount(nameInput, balanceInput, idInput);
                    BankService.AddAccountToMasterList(newSavingsAccount);
                    SavingsRepo.AddAccountToSavingsList(newSavingsAccount);
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

                var newCheckingAccount = CheckingRepo.CreateCheckingAccount(nameInput, balanceInput, idInput);
                BankService.AddAccountToMasterList(newCheckingAccount);
                CheckingRepo.AddAccountToCheckingList(newCheckingAccount);
                _console.WriteLine("Account created");
            }
            else
            {
                _console.WriteLine("Please enter a valid option");
            }
        }

        public void Deposit()
        {
            _console.WriteLine("What account do you want to deposit into: \r\n " +
                                "1. Savings\r\n " +
                                "2. Checking");
            var command = _console.ReadLine().ToLower();

            if (command == "1")
            {

                if (SavingsRepo.GetAllSavingsAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to deposit funds:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates savings account, then deposits funds
                if (SavingsRepo.ValidateSavingsAccount(accountInput))
                {
                    ValidatedSavingsAccountAndDeposit(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
                
            }
            else if (command == "2")
            {
                //checks if accounts are present
                if (CheckingRepo.GetAllCheckingAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to deposit funds:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates checking account, then deposits funds
                if (CheckingRepo.ValidateCheckingAccount(accountInput))
                {
                    ValidatedCheckingAccountAndDeposit(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
            }
            else
            {
                _console.WriteLine("Please enter a valid option");
            }
        }

        public void Withdraw()
        {
            _console.WriteLine("What account do you want to withdraw from: \r\n " +
                                "1. Savings\r\n " +
                                "2. Checking");
            var command = _console.ReadLine().ToLower();

            if (command == "1")
            {
                //checks if accounts are present
                if (SavingsRepo.GetAllSavingsAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to withdraw funds:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates savings account, then withdraws funds
                if (SavingsRepo.ValidateSavingsAccount(accountInput))
                {
                    ValidatedSavingsAccountAndWithdraw(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
            }
            else if (command == "2")
            {
                //checks if accounts are present
                if (CheckingRepo.GetAllCheckingAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to withdraw funds:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates checking account, then withdraws funds
                if (CheckingRepo.ValidateCheckingAccount(accountInput))
                {
                    ValidatedCheckingAccountAndWithdraw(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
            }
            else
            {
                _console.WriteLine("Please enter a valid option");
            }
        }

        public void Transfer()
        {
            _console.WriteLine("What account do you want to transfer from: \r\n " +
                                "1. Savings\r\n " +
                                "2. Checking");
            var command = _console.ReadLine().ToLower();

            if (command == "1")
            {
                //checks if accounts are present
                if (SavingsRepo.GetAllSavingsAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to transfer funds from:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates savings account, then transfers funds
                if (SavingsRepo.ValidateSavingsAccount(accountInput))
                {
                    SavingsToCheckingTransfer(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
            }
            else if (command == "2")
            {
                //checks if accounts are present
                if (CheckingRepo.GetAllCheckingAccounts().Count == 0)
                {
                    _console.WriteLine("No Accounts Present");
                    return;
                }

                _console.WriteLine("Please select account to transfer funds from:");
                var accountInput = Convert.ToInt32(_console.ReadLine());

                //validates checking account, then transfers funds
                if (CheckingRepo.ValidateCheckingAccount(accountInput))
                {
                    CheckingToSavingsTransfer(accountInput);
                }
                else
                {
                    _console.WriteLine("Account not present");
                }
            }
            else
            {
                _console.WriteLine("Please enter a valid option");
            }
        }

        public void SeeAllAccounts()
        {
            if (BankService.GetAllAccounts().Count > 0)
            {
                _console.WriteLine("Displaying all accounts");

                //loops through master list
                //then loops account specific lists
                foreach (var account in BankService.GetAllAccounts())
                {
                    if (account is Savings savingsAccount)
                    {
                        _console.WriteLine($"Last Name: {savingsAccount.LastName}\n" +
                                          $"ID: {savingsAccount.ID}\n" +
                                          $"Balance: {savingsAccount.Balance}\n");
                    }
                    else if (account is Checking checkingAccount)
                    {
                        _console.WriteLine($"Last Name: {checkingAccount.LastName}\n" +
                                           $"ID: {checkingAccount.ID}\n" +
                                           $"Balance: {checkingAccount.Balance}\n");
                    }
                }
            }
            else
            {
                _console.WriteLine("The list is empty");
            }
        }

        public void SeeAllSavingsAccounts()
        {
            if (SavingsRepo.GetAllSavingsAccounts().Count > 0)
            {
                _console.WriteLine("Displaying all savings accounts");

                foreach (var customer in SavingsRepo.GetAllSavingsAccounts())
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

        public void SeeAllCheckingAccounts()
        {
            if (CheckingRepo.GetAllCheckingAccounts().Count > 0)
            {
                _console.WriteLine("Displaying all checking accounts");

                foreach (var customer in CheckingRepo.GetAllCheckingAccounts())
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

        public void Search()
        {
            if (BankService.GetAllAccounts().Count > 0)
            {
                _console.WriteLine("Enter account number:");
                var searchInput = Convert.ToInt32(_console.ReadLine());
                _console.WriteLine("Display search results");

                //loops through all accounts
                //then loops through banking or savings based on searchInput
                foreach (var account in BankService.GetAllAccounts())
                {
                    if (account.ID == searchInput && account is Savings)
                    {
                        foreach (var savingsAccount in SavingsRepo.GetAllSavingsAccounts())
                        {
                            if (savingsAccount.ID == searchInput)
                            {
                                _console.WriteLine($"Last Name: {savingsAccount.LastName}\n" +
                                           $"ID: {savingsAccount.ID}\n" +
                                           $"Balance: {savingsAccount.Balance}\n");
                            }
                        }
                    }
                    if (account.ID == searchInput && account is Checking)
                    {
                        foreach (var checkingAccount in CheckingRepo.GetAllCheckingAccounts())
                        {
                            if (checkingAccount.ID == searchInput)
                            {
                                _console.WriteLine($"Last Name: {checkingAccount.LastName}\n" +
                                           $"ID: {checkingAccount.ID}\n" +
                                           $"Balance: {checkingAccount.Balance}\n");
                            }
                        }
                    }
                }
            }
            else
            {
                _console.WriteLine("The list is empty");
            }
        }

        /*-----------------------------Helper Methods----------------------------------------*/

        public void ValidatedSavingsAccountAndDeposit(int accountInput)
        {
            _console.WriteLine("Amount to deposit:");
            var depositAmount = Convert.ToDecimal(_console.ReadLine());

            foreach (var customer in SavingsRepo.GetAllSavingsAccounts())
            {
                if (customer.ID == accountInput)
                {
                    customer.Deposit(depositAmount);
                }
            }
            _console.WriteLine("Deposit successful");
        }

        public void ValidatedCheckingAccountAndDeposit(int accountInput)
        {
            _console.WriteLine("Amount to deposit:");
            var depositAmount = Convert.ToDecimal(_console.ReadLine());

            foreach (var customer in CheckingRepo.GetAllCheckingAccounts())
            {
                if (customer.ID == accountInput)
                {
                    customer.Deposit(depositAmount);
                }
            }
            _console.WriteLine("Deposit successful");
        }

        public void ValidatedSavingsAccountAndWithdraw(int accountInput)
        {
            _console.WriteLine("Amount to withdraw:");
            var depositAmount = Convert.ToDecimal(_console.ReadLine());

            foreach (var customer in SavingsRepo.GetAllSavingsAccounts())
            {
                if (customer.ID == accountInput)
                {
                    customer.Withdraw(depositAmount);
                }
            }
            _console.WriteLine("Withdraw successful");
        }

        public void ValidatedCheckingAccountAndWithdraw(int accountInput)
        {
            _console.WriteLine("Amount to withdraw:");
            var depositAmount = Convert.ToDecimal(_console.ReadLine());

            foreach (var customer in CheckingRepo.GetAllCheckingAccounts())
            {
                if (customer.ID == accountInput)
                {
                    customer.Withdraw(depositAmount);
                }
            }
            _console.WriteLine("Withdraw successful");
        }

        public void CheckingToSavingsTransfer(int accountInput)
        {
            _console.WriteLine("Amount to transfer:");
            var transferAmount = Convert.ToDecimal(_console.ReadLine());

            _console.WriteLine("Please select account to transfer funds to:");
            var accountToReceiveInput = Convert.ToInt32(_console.ReadLine());

            //validates savings account
            if (!SavingsRepo.ValidateSavingsAccount(accountToReceiveInput))
            {
                _console.WriteLine("Account not present");
            }

            foreach (var customer in SavingsRepo.GetAllSavingsAccounts())
            {
                //if account exists, completes the transfer method
                if (customer.ID == accountToReceiveInput)
                {
                    customer.Deposit(transferAmount);

                    foreach (var checkingAccount in CheckingRepo.GetAllCheckingAccounts())
                    {
                        //checks if account exists
                        if (checkingAccount.ID == accountInput)
                        {
                            checkingAccount.Withdraw(transferAmount);
                        }
                    }
                    _console.WriteLine("Transfer successful");
                }
            }
        }

        public void SavingsToCheckingTransfer(int accountInput)
        {
            _console.WriteLine("Amount to transfer:");
            var transferAmount = Convert.ToDecimal(_console.ReadLine());

            _console.WriteLine("Please select account to transfer funds to:");
            var accountToReceiveInput = Convert.ToInt32(_console.ReadLine());

            //validates checking account
            if (!CheckingRepo.ValidateCheckingAccount(accountToReceiveInput))
            {
                _console.WriteLine("Account not present");
            }

            foreach (var customer in CheckingRepo.GetAllCheckingAccounts())
            {
                //if account exists, completes the transfer method
                if (customer.ID == accountToReceiveInput)
                {
                    customer.Deposit(transferAmount);

                    foreach (var savingsAccount in SavingsRepo.GetAllSavingsAccounts())
                    {
                        //checks if account exists
                        if (savingsAccount.ID == accountInput)
                        {
                            savingsAccount.Withdraw(transferAmount);
                        }
                    }
                    _console.WriteLine("Transfer successful");
                }
            }
        }
    }
}
