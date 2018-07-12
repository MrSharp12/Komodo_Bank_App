using System;
using KomodoBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBank.Tests
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Savings account must have 1000 dollars")]
        public void SavingsAccount_CreationExceptionError_ShouldSucceed()
        {
            //arrange
            var savingsAccount = new Savings("Jeffries", 500m, 233456);
            
        }
    }
}
