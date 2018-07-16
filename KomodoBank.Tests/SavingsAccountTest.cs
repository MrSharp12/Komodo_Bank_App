using System;
using KomodoBank.BLL;
using KomodoBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBank.Tests
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        public void SavingsAccount_BaseBalanceValue_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings();

            //act
            var expected = 300m;
            var actual = savingsAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SavingsAccount_CreateSavingsAccountMethodWithMinimumBalance_ShouldSucceed()
        {
            //arrange
            var newSavingsAccount = new SavingsRepo();

            //act
            var expected = 300m;
            var actual = newSavingsAccount.CreateSavingsAccountWithMinimumBalance("Jeffries", 123456);

            //assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        public void SavingsAccount_CreateAdditionalSavingsAccountMethod_ShouldSucceed()
        {
            //arrange
            var newSavingsAccount = new SavingsRepo();

            //act
            var expected = 1000m;
            var actual = newSavingsAccount.CreateSavingsAccount("Jeffries", 1000m, 123456);

            //assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Account must have 300 dollars to open")]
        public void SavingsAccount_CreationOfSavingsAccountWithout300DollarWillThrowException_ShouldSucceed()
        {
            //arrange
            var newSavingsRepo = new SavingsRepo();
            var savingsAccount = newSavingsRepo.CreateSavingsAccount("Jeffries", 200m, 123456);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Insufficient funds")]
        public void SavingsAccount_WithdrawInsufficientFundsExceptionError_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 2000m, 233456);
            savingsAccount.Withdraw(3000m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "You may not remove funds greater than or equal to 10,000 dollars in one transaction")]
        public void SavingsAccount_WithdrawLargerThanTenGrandExceptionError_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            savingsAccount.Withdraw(15000m);
        }

        [TestMethod]
        public void SavingsAccount_WithdrawMethod_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            savingsAccount.Withdraw(1000m);

            //act
            var expected = 19000m;
            var actual = savingsAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void SavingsAccount_DepositMethod_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            savingsAccount.Deposit(1000m);

            //act
            var expected = 21000m;
            var actual = savingsAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SavingsAccount_TransferMethod_ValidateThatCheckingBalanceIncreases_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            var checkingAccount = new Checking("Jeffries", 3000m, 123456);
            savingsAccount.Transfer(1000m, checkingAccount);

            //act
            var expected = 4000m;
            var actual = checkingAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SavingsAccount_TransferMethod_ValidateThatSavingBalanceDecreases_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            var checkingAccount = new Checking("Jeffries", 3000m, 123456);
            savingsAccount.Transfer(1000m, checkingAccount);

            //act
            var expected = 19000m;
            var actual = savingsAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Insufficient funds")]
        public void SavingsAccount_TransferInsufficientFundsExceptionError_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            var checkingAccount = new Checking("Jeffries", 3000m, 123456);
            savingsAccount.Transfer(3000000m, checkingAccount);
        }

        [TestMethod]
        public void SavingsAccount_GetAllSavingsAccounts_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 20000m, 233456);
            var savingsAccount1 = new Savings("Sharp", 3000m, 123456);
            var savingsAccount2 = new Savings("Stewart", 4000m, 223456);
            var savingsRepo = new SavingsRepo();
            savingsRepo.AddAccountToSavingsList(savingsAccount);
            savingsRepo.AddAccountToSavingsList(savingsAccount1);
            savingsRepo.AddAccountToSavingsList(savingsAccount2);

            //act
            var expected = 3;
            var actual = savingsRepo.GetAllSavingsAccounts().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
