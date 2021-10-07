using Challenge5_POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge5_Tests
{
    [TestClass]
    public class CustomerPOCOTests
    {
        [TestMethod]
        public void SetCustomerID_ShouldSetCorrectInt()
        {
            Customer customer = new Customer();
            customer.ID = 1;
            int expected = 1;
            int actual = customer.ID;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCustomerFirstName_ShouldSetCorrectString()
        {
            Customer customer = new Customer();
            customer.FirstName = "Jessica";
            string expected = "Jessica";
            string actual = customer.FirstName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCustomerLastName_ShouldSetCorrectString()
        {
            Customer customer = new Customer();
            customer.LastName = "Flores";
            string expected = "Flores";
            string actual = customer.LastName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCustomerType_ShouldSetCorrectCustomerType()
        {
            Customer customer = new Customer();
            customer.TypeOfCustomer = CustomerType.Current;
            CustomerType expected = CustomerType.Current;
            CustomerType actual = customer.TypeOfCustomer;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCustomerEmail_ShouldSetCorrectString()
        {
            Customer customer = new Customer();
            customer.Email = "flores.jessica@gmail.com";
            string expected = "flores.jessica@gmail.com";
            string actual = customer.Email;
            Assert.AreEqual(expected, actual);
        }

    }
}
