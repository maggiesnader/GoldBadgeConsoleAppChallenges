using Challenge4_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_UI
{
    class ProgramUI
    {
        private OutingRepo outingRepo = new OutingRepo();

        public void Run()
        {
            SeedOutingList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Komodo Insurance Outing Tracker:\n" +
                    "Enter the number of the task you wish you complete:" +
                    "1. Create a new Outing\n" +
                    "2. Display all Outings.\n" +
                    "3. Display total cost of outings to date by type of outing (Bowling, Gold, etc).\n" +
                    "4. Display total cost of outings to date.\n" +
                    "5. Update Outing Info.\n" +
                    "6. Exit Program.\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //CreateNewOuting
                        break;
                    case "2":
                        //DisplayAllOutings
                        break;
                    case "3":
                        //DisplayCostByType
                        break;
                    case "4":
                        //DisplayTotalCost
                        break;
                    case "5":
                        //UpdateOuting
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                }
            }
        }




        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
        }

        //SEEDLIST
    }
}
