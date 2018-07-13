using System;
using System.Diagnostics.CodeAnalysis;
using KomodoBank.BLL;
using KomodoBank.Data;
using KomodoBankUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace 
    KomodoBank.Tests
{


    //--[Create New Account] command one
    [TestClass]
    public class ProgramUITests
    {
        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_NewSavingsAccountWithMin()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "1", "1", "Y", "Jeffries", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do?\r\n ");
        }
        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_ExitProgram()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "9", "1", "Y", "Jeffries", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do?\r\n ");
        }

        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_NewSavingsAccountWithoutMin()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "1", "1", "N", "Jeffries", "500", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do?\r\n ");
        }
        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_NewSavingsAccount_EnterVailidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "1", "1", "A", "Jeffries", "500", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }
        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_NewAccount_EnterVailidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "1", "3", "A", "Jeffries", "500", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }

        [TestMethod]
        public void ProgramUI_CreateNewAccount_CommandOne_NewCheckingAccount()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "1", "2", "Jeffries", "500", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do?\r\n ");
        }

        //--[Deposit] Command two
        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInSavingsAccount_NoAccountPresent()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "1", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do?\r\n ");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInSavingsAccount_DepositSuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "1", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Deposit successful");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInSavings_EnterValidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "idk", "4140", "100" });
            var programUI = new ProgramUI(mockConsole);
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInCheckingAccount_NoAccountPresent()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "2", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "What would you like to do");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInChecking_DepositSuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "2", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Deposit successful");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_DepositMoneyInChecking_PleaseEnterValidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "2", "Idontknow", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }

        //--[Withdraw] command three --Savings Account
        [TestMethod]
        public void ProgramUI_Withdraw_CommandThree_WithdrawtMoneyFromSavingsAccount_NoAccountPresent()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "3", "1", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }

        [TestMethod]
        public void ProgramUI_Withdraw_CommandThree_WithdrawMoneyFromSavings_WithdrawSuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "3", "1", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Withdraw successful");
        }
        //--[Withdraw] command three --Checking Account

        [TestMethod]
        public void ProgramUI_Withdraw_CommandThree_WithdrawMoneyFromChecking_WithdrawSuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "3", "2", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Withdraw successful");
        }

        [TestMethod]
        public void ProgramUI_Deposit_CommandTwo_PleaseEnterValidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "3", "Idontknow", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }

        [TestMethod]
        public void ProgramUI_Withdraw_CommandThree_WithdrawtMoneyFromCheckingAccount_NoAccountPresent()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "3", "2", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }

        //--[Transfer] Command four. Savings
        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyFromSavingsAccount_NoAccountPreset()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "1", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }

        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyFromSavingsToChecking_NoAccountPreset()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "1", "4140", "100", "4145" });
            var programUI = new ProgramUI(mockConsole);
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4140));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }

        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyFromSavingsToChecking_Transferuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "1", "4141", "100", "4140" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 500m, 4140));
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Transfer successful");
        }

        //--[Transfer] Command four. Checking
        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyFromCheckingToSavings_NoAccountPreset()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "2", "4141", "500" });
            var programUI = new ProgramUI(mockConsole);

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }


        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyToSaving_NoAccountPreset()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "2", "4140", "100", "4145" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 500m, 4140));


            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "No Accounts Present");
        }

        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_TransferMoneyfromCheckingToSavings_Transferuccessful()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "2", "4140", "100", "4141" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 500m, 4140));
            var savingsRepo = programUI.SavingsRepo;
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Transfer successful");
        }

        [TestMethod]
        public void ProgramUI_Transfer_CommandFour_PleaseEnterValidOption()
        {
            //--Arrange
            var mockConsole = new MockConsole(new string[] { "4", "Idontknow", "4141", "100" });
            var programUI = new ProgramUI(mockConsole);
            var checkingRepo = programUI.CheckingRepo;
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //--Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Please enter a valid option");
        }

        [TestMethod]
        public void ProgramUI_SeeAllAccount_SearchAllSavingsAccounts_AccountsFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "5", "savings", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var savingsRepo = programUI.SavingsRepo;
            bankService.AddAccountToMasterList(new Savings("Jeffries", 400m, 4141));
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("Displaying all accounts"));
        }

        [TestMethod]
        public void ProgramUI_SeeAllAccount_SearchAllCheckingAccounts_AccountsFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "5", "checking", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("The list is empty"));
        }

        [TestMethod]
        public void ProgramUI_SeeAllAccount_SearchAllAccounts_AccountsListEmpty()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "5", "checking", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var checkingRepo = programUI.CheckingRepo;
            bankService.AddAccountToMasterList(new Checking("Jeffries", 400m, 4141));
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("Displaying all accounts"));
        }


        [TestMethod]
        public void ProgramUI_SeeAllCheckingAccountAccount_SearchAllCheckingAccountAccounts_AccountsFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "6", "checking", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var checkingRepo = programUI.CheckingRepo;
            bankService.AddAccountToMasterList(new Checking("Jeffries", 400m, 4141));
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("Displaying all checking accounts"));
        }

        [TestMethod]
        public void ProgramUI_SeeAllCheckingAccounts_SearchAllCheckingAccounts_AccountsListEmpty()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "6", "checking", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("The list is empty"));
        }


        [TestMethod]
        public void ProgramUI_SeeAllSavingsAccount_SearchAllSavingsAccounts_AccountsFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "7", "savings", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var savingsRepo = programUI.SavingsRepo;
            bankService.AddAccountToMasterList(new Savings("Jeffries", 400m, 4141));
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("Displaying all savings accounts"));
        }

        [TestMethod]
        public void ProgramUI_SeeAllSavingsAccount_SearchAllSavingsAccounts_AccountsListEmpty()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "7", "savings", "Jeffries", "4141", "400" });
            var programUI = new ProgramUI(mockConsole);


            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, ("The list is empty"));
        }


        [TestMethod]
        public void ProgramUI_Search_SearchSavingsAccountListForSpecificAccount_AccountFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "8", "4141" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var savingsRepo = programUI.SavingsRepo;
            bankService.AddAccountToMasterList(new Savings("Jeffries", 400m, 4141));
            savingsRepo.AddAccountToSavingsList(new Savings("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Jeffries");
        }


        [TestMethod]
        public void ProgramUI_Search_SearchCheckingAccountListForSpecificAccount_CheckingAccountFound()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "8", "4141", "Jeffries", "4141", "400m" });
            var programUI = new ProgramUI(mockConsole);
            var bankService = programUI.BankService;
            var checkingRepo = programUI.CheckingRepo;
            bankService.AddAccountToMasterList(new Checking("Jeffries", 400m, 4141));
            checkingRepo.AddAccountToCheckingList(new Checking("Jeffries", 400m, 4141));

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Jeffries");
        }

        [TestMethod]
        public void ProgramUI_Search_SearchCheckingAccountListForSpecificAccount_CheckingAccountListEmpty()
        {
            //--Arrang
            var mockConsole = new MockConsole(new string[] { "8", "4141" });
            var programUI = new ProgramUI(mockConsole);

            //-- Act
            programUI.Run();

            //--Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "The list is empty");
        }
    }
}
