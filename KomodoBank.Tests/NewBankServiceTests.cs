using System;
using KomodoBank.BLL;
using KomodoBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBank.Tests
{
    [TestClass]
    public class NewBankServiceTests
    {
        private BankService _bankServiceList;
        private Savings _savings;
        private Checking _checking;
        private Checking _newCheckingCustomer = new Checking();
        private Checking _newCheckingCustomerTwo = new Checking();
        private Savings _newSavingsCustomer = new Savings();

        [TestInitialize]
        public void Arrange()
        {
            _bankServiceList = new BankService();
            var checkingCustomer1 = _bankServiceList.CreateCheckingAccount("Jeffries", 2000m, 123456);
            var checkingCustomer2 = _bankServiceList.CreateCheckingAccount("Sharp", 200m, 345678);
            var savingsCustomer1 = _bankServiceList.CreateSavingsAccount("Jeffries", 200000m, 678904);
            _bankServiceList.AddAccountToMasterList(checkingCustomer1);
            _bankServiceList.AddAccountToMasterList(checkingCustomer2);
            _bankServiceList.AddAccountToMasterList(savingsCustomer1);
        }

        [TestMethod]
        public void AddToListMethod_ShouldSucceed()
        {
            var expected = 3;
            var actual = _bankServiceList.GetAllAccounts().Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchCustomersInList_ShouldSucceed()
        {
            //arrange
            var _bankServiceList = new BankService();
            var checkingCustomer1 = _bankServiceList.CreateCheckingAccount("Jeffries", 2000m, 123456);
            var checkingCustomer2 = _bankServiceList.CreateCheckingAccount("Sharp", 200m, 345678);
            var savingsCustomer1 = _bankServiceList.CreateSavingsAccount("Jeffries", 200000m, 678904);
            _bankServiceList.AddAccountToMasterList(checkingCustomer1);
            _bankServiceList.AddAccountToMasterList(checkingCustomer2);
            _bankServiceList.AddAccountToMasterList(savingsCustomer1);

            //act
            var listOfSearch = _bankServiceList.Search("Sharp");

            //assert
            Assert.AreEqual(listOfSearch[0].LastName, "Sharp");
        }
    }
}
