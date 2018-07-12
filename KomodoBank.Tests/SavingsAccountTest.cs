using System;
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
        [ExpectedException(typeof(ArgumentException),
        "Insufficient funds")]
        public void SavingsAccount_InsufficientFundsExceptionError_ShouldSucceed()
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
    }
}
