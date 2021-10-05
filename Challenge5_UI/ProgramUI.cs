using Challenge5_POCO;
using Challenge5_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5_UI
{
    class ProgramUI
    {
        private CustomerRepo customerRepo = new CustomerRepo();
        private List<Customer> _ListOfCustomers = new List<Customer>();

        public void Run()
        {
            SeedCustomerList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                DisplayMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewCustomer();
                        break;
                    case "2":
                        //DisplayAllCustomersAphabetically();
                        PressAnyKey();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        //DeleteCustomer();
                        break;
                    case "5":
                        //
                        break;
                    case "6":
                        Exit();
                        keepRunning = false;
                        break;
                    default:
                        ValidNumber();
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Komodo Insurance Customer Greeting Email Sorter\n" +
                "Enter the number of the tast you would like to complete (1, 2, 4, 5, 6, or 7):\n" +
                "1. Create a new Customer.\n" +
                "2. View all customers in alphabetical order.\n" +
                "3. Update an existing Customer.\n" +
                "4. Delete an existing Customer.\n" +
                "5. \n" +
                "6. Exit Program\n");
        }

        private void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            Console.WriteLine("Add a new Customer:\n\n" +
                "Enter the Customer's First Name:\n");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Last Name:\n");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Email:\n");
            newCustomer.Email = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Type (1, 2 or 3):\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.TypeOfCustomer = (CustomerType)typeAsInt;

            customerRepo.AddCustomerToList(newCustomer);
            Console.WriteLine("\nNew Customer Added. Press any key to continue:");
            Console.ReadKey();
        }

        //DisplayAlphabetically

        private void UpdateCustomer()
        {
            DisplayAlphabetically();
            Console.WriteLine("\nEnter the ID number of the Customer to be updated:\n");
            int oldCustomer = int.Parse(Console.WriteLine());
            Customer newCustomer = new Customer();

            Console.Clear();
            Console.WriteLine("Enter the Customer's First Name:\n");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Customer's Last Name:\n");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Email:\n");
            newCustomer.Email = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Type (1, 2 or 3):\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.TypeOfCustomer = (CustomerType)typeAsInt;

            bool wasUpdated = customerRepo.UpdateExistingCustomer(oldCustomer, newCustomer);
            if (wasUpdated)
            {
                Console.Clear();
                Console.WriteLine("\nCustomer successfully updated!\n\n");
                PressAnyKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n Unable to update outing. \n\n");
                PressAnyKey();
            }

        }

        private void DeleteCustomer()
        {
            DisplayAlphabetically();
            Console.WriteLine("\nEnter the ID number of the Customer to be deleted:\n");
            int oldCustomer = int.Parse(Console.WriteLine());
            Customer newCustomer = new Customer();

            if (newCustomer == null)
            {
                return false;
            }
            int initialCount = _ListOfCustomers.Count;
            _ListOfCustomers.Remove(newCustomer);

            if (initialCount > _ListOfCustomers.Count)
            {
                return true;
            }
            return false;
        }


        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
        }

        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("\n\nGoodbye!\n" +
                "Press any key to close window.");
            Console.ReadKey();
        }

        private void ValidNumber()
        {
            Console.Clear();
            Console.WriteLine("\n\nNot a valid number. Press enter to try again.");
            Console.ReadKey();
        }
    }
}
