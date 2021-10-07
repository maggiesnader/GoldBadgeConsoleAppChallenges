using Challenge5_POCO;
using Challenge5_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge5_Tests
{
    [TestClass]
    public class CustomerRepoTests
    {
        private CustomerRepo _repo = new CustomerRepo();

        [TestInitialize]
        public void Arrange()
        {
            Customer customer = new Customer("Jessica", "Flores", CustomerType.Current, "flores.jessica@gmail.com");
            _repo.AddCustomerToList(customer);
        }

        [TestMethod]
        public void AddCustomerToList_CustomerIsNotNull_ReturnTrue()
        {
            Customer customer = new Customer("Jessica", "Flores", CustomerType.Current, "flores.jessica@gmail.com");
            CustomerRepo repo = new CustomerRepo();
            bool customerResult = repo.AddCustomerToList(customer);
            Assert.IsTrue(customerResult);
        }

        [TestMethod]
        public void AddCustomerToList_CustomerIsNull_ReturnFalse()
        {
            Customer customer = null;
            CustomerRepo repo = new CustomerRepo();
            bool customerResult = repo.AddCustomerToList(customer);
            Assert.IsFalse(customerResult);
        }

        [TestMethod]
        public void ViewCustomerByID_CustomerExists_ReturnOuting()
        {
            Customer customer = new Customer("Jessica", "Flores", CustomerType.Current, "flores.jessica@gmail.com");
            _repo.AddCustomerToList(customer);
            int id = 1;
            Customer customerResult = _repo.ViewCustomerByID(id);
            Assert.IsNotNull(customerResult);
            Assert.AreEqual(customerResult.ID, id);
        }

        [TestMethod]
        public void ViewCustomerById_CustomerDoesNotExist_ReturnNull()
        {
            int id = 0;
            Customer customerResult = _repo.ViewCustomerByID(id);
            Assert.IsNull(customerResult);
        }

        [TestMethod]
        public void UpdateExistingCustomer_ShouldReturnTrue()
        {
            Customer customer = new Customer("Jessica", "Flores", CustomerType.Current, "flores.jessica@gmail.com");
            bool updateResult = _repo.UpdateExistingCustomer(1, customer);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(10, false)]
        public void UpdateExistingCustomer_ShouldMatchGivenBool(int id, bool shouldUpdate)
        {
            Customer customer = new Customer("Jessica", "Flores", CustomerType.Current, "flores.jessica@gmail.com");
            bool updateResult = _repo.UpdateExistingCustomer(id, customer);
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteCustomer_ShouldReturnTrue()
        {
            int id = 1;
            bool deleteResult = _repo.DeleteCustomer(id);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void DeleteCustomer_ShouldReturnFalse()
        {
            Customer customer = new Customer();
            bool deleteResult = _repo.DeleteCustomer(customer.ID);
            Assert.IsFalse(deleteResult);
        }
    }
}
