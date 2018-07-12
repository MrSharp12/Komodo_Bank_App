using System;
using KomodoBank.BLL;
using KomodoBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBank.Tests
{
    [TestClass]
    public class CheckingAccountTests
    {
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException),
        //"Insufficient funds")]
        //public void CheckingAccount_InsufficientFundsExceptionError_ShouldSucceed()
        //{
        //    //arrange
        //    var checkingAccount = new Checking("Jeffries", 2000m, 233456);
        //    checkingAccount.Withdraw(3000m);

        //}

        [TestMethod]
        public void CheckingAccount_DepositMethod_ShouldSucceed()
        {
            //arrange
            var checkingAccount = new Savings("Jeffries", 20000m, 233456);
            checkingAccount.Deposit(1000m);

            //act
            var expected = 21000m;
            var actual = checkingAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void CheckingAccount_WithdrawMethod_ShouldSucceed()
        //{
        //    //arrange
        //    var checkingAccount = new Savings("Jeffries", 20000m, 233456);
        //    checkingAccount.Withdraw(1000m);

        //    //act
        //    var expected = 19000m;
        //    var actual = checkingAccount.Balance;

        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void CheckingAccount_TransferMethod_ValidateThatSavingsBalanceIncreases_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 3000m, 233456);
            var checkingAccount = new Checking("Jeffries", 20000m, 123456);
            checkingAccount.Transfer(1000m, savingsAccount);

            //act
            var expected = 4000m;
            var actual = savingsAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckingAccount_TransferMethod_ValidateThatCheckingBalanceDecreases_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 3000m, 233456);
            var checkingAccount = new Checking("Jeffries", 20000m, 123456);
            checkingAccount.Transfer(1000m, savingsAccount);

            //act
            var expected = 19000m;
            var actual = checkingAccount.Balance;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckingAccount_CreateAdditionalCheckingAccountMethodIsTypeOf_ShouldSucceed()
        {
            //arrange
            var newCheckingAccount = new BankService();
            var actual = newCheckingAccount.CreateCheckingAccount("Jeffries", 1000m, 123456);

            //act

            //assert
            Assert.IsInstanceOfType(actual, typeof(Checking));
        }

        [TestMethod]
        public void CheckingAccount_CreateAdditionalCheckingAccountMethod_ShouldSucceed()
        {
            //arrange
            var newCheckingAccount = new BankService();

            //act
            var expected = 1000m;
            var actual = newCheckingAccount.CreateCheckingAccount("Jeffries", 1000m, 123456);

            //assert
            Assert.AreEqual(expected, actual.Balance);
        }
    }
}
