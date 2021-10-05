using Challenge5_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5_Repo
{
    public class CustomerRepo
    {
        private List<Customer> _ListOfCustomers = new List<Customer>();
        private int _idCounter = default;

        public bool AddCustomerToList(Customer customerToBeAdded)
        {
            if (customerToBeAdded != null)
            {
                customerToBeAdded.ID = ++_idCounter;
                _ListOfCustomers.Add(customerToBeAdded);
                return true;
            }
            return false;
        }

        public List<Customer> ViewAllCustomers()
        {
            return (_ListOfCustomers);
        }

        public Customer ViewCustomerByID(int id)
        {
            foreach (Customer customer in _ListOfCustomers)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public bool UpdateExistingCustomer(int id, Customer updatedCustomerInfo)
        {
            Customer oldCustomerInfo = ViewCustomerByID(id);
            if (oldCustomerInfo != null)
            {
                oldCustomerInfo.FirstName = updatedCustomerInfo.FirstName;
                oldCustomerInfo.LastName = updatedCustomerInfo.LastName;
                oldCustomerInfo.TypeOfCustomer = updatedCustomerInfo.TypeOfCustomer;
                oldCustomerInfo.Email = updatedCustomerInfo.Email;
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = ViewCustomerByID(id);
            if (customer == null)
            {
                return false;
            }
            int initialCount = _ListOfCustomers.Count;
            _ListOfCustomers.Remove(customer);
            if(initialCount > _ListOfCustomers.Count)
            {
                return true;
            }
            return false;
        }

    }
}
