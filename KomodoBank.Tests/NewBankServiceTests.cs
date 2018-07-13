using System;
using KomodoBank.BLL;
using KomodoBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBank.Tests
{
    [TestClass]
    public class NewBankServiceTests
    {
        

        [TestMethod]
        public void AddToListMethod_ShouldSucceed()
        {
            //arrange
            var bankService = new BankService();
            var newSavingsAccountOne = new Savings("Jeffries", 1000, 121212);
            var newSavingsAccountTwo = new Savings("Sharp", 2000, 221212);
            var newCheckingAccountOne = new Checking("Jeffries", 2500, 343434);
            bankService.AddAccountToMasterList(newSavingsAccountOne);
            bankService.AddAccountToMasterList(newSavingsAccountOne);
            bankService.AddAccountToMasterList(newSavingsAccountOne);

            //act
            var expected = 3;
            var actual = bankService.GetAllAccounts().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchAllCustomersInList_ShouldSucceed()
        {
            //arrange
            var bankService = new BankService();
            var newSavingsAccountOne = new Savings("Jeffries", 1000, 121212);
            var newSavingsAccountTwo = new Savings("Sharp", 2000, 221212);
            var newCheckingAccountOne = new Checking("Jeffries", 2500, 343434);
            bankService.AddAccountToMasterList(newSavingsAccountOne);
            bankService.AddAccountToMasterList(newSavingsAccountOne);
            bankService.AddAccountToMasterList(newSavingsAccountOne);

            //act
            var expected = 3;
            var actual = bankService.GetAllAccounts().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
