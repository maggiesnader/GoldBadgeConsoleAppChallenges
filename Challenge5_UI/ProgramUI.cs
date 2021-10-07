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
            Console.WriteLine("Komodo Insurance Customer Greeting Email Sorter\n\n" +
                "Enter the number of the task you would like to complete (1, 2, 4 or 5):\n" +
                "\t1. Create a new Customer.\n" +
                "\t2. View all customers in alphabetical order.\n" +
                "\t3. Update an existing Customer.\n" +
                "\t4. Delete an existing Customer.\n" +
                "\t5. Exit Program\n");
        }

        private void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            Console.WriteLine("Add a new Customer:\n\n" +
                "\nEnter the Customer's First Name:\n");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the Customer's Last Name:\n");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("\nEnter the Customer's Email:\n");
            newCustomer.Email = Console.ReadLine();

            Console.WriteLine("\nEnter the Customer's Type (1, 2 or 3):\n" +
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
            Console.WriteLine("\nCustomer List:\n");
            Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                "Last Name", "First Name", "ID#", "Type", "Greeting Email");
            Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                "____________", "____________", "___", "__________", "_______________________________________________________________________________");
            Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                "------------", "------------", "---", "----------", "-------------------------------------------------------------------------------");
            foreach (Customer customer in listOfCustomers)
            {
                if (customer.TypeOfCustomer == CustomerType.Current)
                {
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        customer.LastName, customer.FirstName, customer.ID, customer.TypeOfCustomer, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        "------------", "------------", "---", "----------", "-------------------------------------------------------------------------------");
                }
                if (customer.TypeOfCustomer == CustomerType.Past)
                {
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        customer.LastName, customer.FirstName, customer.ID, customer.TypeOfCustomer, "It's been a long time since we've heard from you, we want you back.");
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        "------------", "------------", "---", "----------", "-------------------------------------------------------------------------------");
                }
                if (customer.TypeOfCustomer == CustomerType.Potential)
                {
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        customer.LastName, customer.FirstName, customer.ID, customer.TypeOfCustomer, "We currently have the lowest rates on Helicopter Insurance!");
                    Console.WriteLine("{0, -12} {1, -12} {2, -3} {3, -10} {4, -50}", 
                        "------------", "------------", "---", "----------", "-------------------------------------------------------------------------------");
                }
            }
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
                Console.Clear();
                Console.WriteLine("\nThe Customer was successfully deleted.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nThe Customer could not be deleted.");
            }
            PressAnyKey();
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
