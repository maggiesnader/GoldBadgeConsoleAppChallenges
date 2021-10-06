using Challenge5_POCO;
using Challenge5_Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5_UI
{
    class ProgramUI
    {
        private CustomerRepo customerRepo = new CustomerRepo();
        private List<Customer> _ListOfCustomers = new List<Customer>();
        private DataTable dataTable = new DataTable();


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
                        DisplayAlphabetically();
                        PressAnyKey();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        //MessageToBeSent();
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

        private void DisplayAlphabetically()
        {
            Console.Clear();
            List<Customer> listOfCustomers = customerRepo.ViewAllCustomers();
            Console.WriteLine("{0,15} {1,15} {2, 15}", "Last Name", "First Name", "Type");
            Console.WriteLine("{0,15} {1,15} {2, 15}", "---------------", "---------------", "---------------");
            foreach (Customer customer in listOfCustomers)
            {
                Console.WriteLine("{0,15} {1,15} {2, 15}", customer.LastName, customer.FirstName, customer.TypeOfCustomer);
            }


            //customerRepo.ListToTable(listOfCustomers);
            // DataTable dt = new DataTable(); 
            // dt.Columns.Add("Last Name", typeof(string));

            //  foreach (Customer customer in listOfCustomers)
            //  {
            //       dt.Rows.Add(new object[] { customer.LastName });
            //   }


            //foreach (Customer customer in listOfCustomers)
            //{
            //    Console.WriteLine($"\n{customer.ID}\t" +
            //         $"{customer.LastName}\t" +
            //         $"{customer.FirstName}\n");
            // }
        }

        private void UpdateCustomer()
        {
            DisplayAlphabetically();
            Console.WriteLine("\nEnter the ID number of the Customer to be updated:\n");
            int oldCustomer = int.Parse(Console.ReadLine());
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
            Console.Clear();
            DisplayAlphabetically();
            Console.WriteLine("\nEnter the ID number of the Customer to be deleted:\n");
            int userInput = int.Parse(Console.ReadLine());

            bool wasDeleted = customerRepo.DeleteCustomer(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("\nThe Customer was successfully delted.");
            }
            else
            {
                Console.WriteLine("\nThe Customer could not be deleted.");
            }
            PressAnyKey();
        }

        //MessageToBeSent

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

        private void SeedCustomerList()
        {
            Customer seedCustomer1 = new Customer("Maggie", "Snader", CustomerType.Potential, "snader.maggie@gmail.com");
            Customer seedCustomer2 = new Customer("Josh", "Snader", CustomerType.Potential, "snader.josh@gmail.com");
            Customer seedCustomer3 = new Customer("Janie", "Gard", CustomerType.Past, "gard.janie@gmail.com");
            Customer seedCustomer4 = new Customer("Blake", "Weishaar", CustomerType.Past, "weishaar.blake@gmail.com");
            Customer seedCustomer5 = new Customer("Rex", "Witham", CustomerType.Current, "witham.rex@gmail.com");
            Customer seedCustomer6 = new Customer("Chelsea", "Herington", CustomerType.Current, "herington.chelsea@gmail.com");

            customerRepo.AddCustomerToList(seedCustomer1);
            customerRepo.AddCustomerToList(seedCustomer2);
            customerRepo.AddCustomerToList(seedCustomer3);
            customerRepo.AddCustomerToList(seedCustomer4);
            customerRepo.AddCustomerToList(seedCustomer5);
            customerRepo.AddCustomerToList(seedCustomer6);

        }

    }
}
