using Challenge4_POCO;
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
                DisplayMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewOuting();
                        break;
                    case "2":
                        DisplayAllOutings();
                        PressAnyKey();
                        break;
                    case "3":
                        DisplayCostByType();
                        break;
                    case "4":
                        DisplayTotalCost();
                        break;
                    case "5":
                        UpdateOuting();
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
            Console.WriteLine("Komodo Insurance Outing Tracker:\n" +
                "Enter the number of the task you wish you complete (1, 2, 3, 4, 5 or 6):\n" +
                "1. Add a new Outing\n" +
                "2. Display all Outings.\n" +
                "3. Display total cost of outings to date by type of outing (Bowling, Golf, etc).\n" +
                "4. Display total cost of all outings to date.\n" +
                "5. Update an Outing's info.\n" +
                "6. Exit Program.\n");
        }

        private void CreateNewOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("Add a New Outing:\n\n" +
                "Enter the outing title:\n");
            newOuting.OutingTitle = Console.ReadLine();

            Console.WriteLine("\nEnter the type of outing (1, 2, 3 or 4):\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newOuting.TypeOfOuting = (OutingType)typeAsInt;

            Console.WriteLine("\nEnter the number of Attendees:\n");
            newOuting.NumberOfAttendees = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Date of the Outing (yyyy, mm, dd):\n");
            newOuting.OutingDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the cost of the outing per person:\n");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the total cost of the event:\n");
            newOuting.TotalCost = decimal.Parse(Console.ReadLine());

            outingRepo.AddOutingToList(newOuting);
            Console.WriteLine("\nNew Outing Added. Press any key to continue:");
            Console.ReadKey();
        }

        private void DisplayAllOutings()
        {
            Console.Clear();
            List<Outing> _ListOfOutings = outingRepo.ViewAllOutings();

            foreach (Outing outing in _ListOfOutings)
            {
                Console.WriteLine($"{outing.OutingTitle}:\n" +
                    $"ID Number: {outing.ID}\n" +
                    $"Type: {outing.TypeOfOuting}\n" +
                    $"Cost Per Person: ${outing.CostPerPerson}\n" +
                    $"Total Cost: ${outing.TotalCost}\n\n");
            }
        }

        private void DisplayCostByType()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("\nEnter the type of outing you would like to see the total cost of(1, 2, 3, or 4):\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");
            string userInputString = Console.ReadLine();
            int userInputInt = int.Parse(userInputString);
            newOuting.TypeOfOuting = (OutingType)userInputInt;

            Console.Clear();
            outingRepo.GetOutingCostTotalByType((OutingType)userInputInt);
            Console.WriteLine("\nOutings:");
            outingRepo.ViewOutingByType((OutingType)userInputInt);
            PressAnyKey();
        }

        private void DisplayTotalCost()
        {
            Console.Clear();
            List<Outing> _ListOfOutings = outingRepo.ViewAllOutings();
            outingRepo.GetTotalCostOfAllOutings(_ListOfOutings);
            PressAnyKey();
        }
        
        private void UpdateOuting()
        {
            DisplayAllOutings();
            Console.WriteLine("\n\nEnter the ID number of the outing to be updated:\n");
            int oldOuting = int.Parse(Console.ReadLine());
            Outing newOuting = new Outing();

            Console.Clear();
            Console.WriteLine("Enter the outing title:\n");
            newOuting.OutingTitle = Console.ReadLine();

            Console.WriteLine("\nEnter the type of outing (1, 2, 3 or 4):\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newOuting.TypeOfOuting = (OutingType)typeAsInt;

            Console.WriteLine("\nEnter the number of Attendees:\n");
            newOuting.NumberOfAttendees = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Date of the Outing (yyyy, mm, dd):\n");
            newOuting.OutingDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the cost of the outing per person:\n");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the total cost of the event:\n");
            newOuting.TotalCost = decimal.Parse(Console.ReadLine());

            bool wasUpdated = outingRepo.UpdateExistingOuting(oldOuting, newOuting);
            if (wasUpdated)
            {
                Console.Clear();
                Console.WriteLine("\nOuting successfully updated!\n\n");
                PressAnyKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nUnable to update outing.\n\n");
                PressAnyKey();
            }
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

        private void SeedOutingList()
        {
            Outing seedOuting1 = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 59.23m, 1480.75m);
            Outing seedOuting2 = new Outing("4 Year Anniversary", OutingType.Bowling, 50, new DateTime(2019, 09, 15), 55.26m, 2763m);
            Outing seedOuting3 = new Outing("Fall 2020", OutingType.AmusementPark, 18, new DateTime(2020, 09, 25), 70.89m, 1276.02m);
            Outing seedOuting4 = new Outing("Fall 2019", OutingType.AmusementPark, 23, new DateTime(2019, 10, 15), 58.35m, 1342.05m);
            Outing seedOuting5 = new Outing("Spring 2020", OutingType.Concert, 30, new DateTime(2020, 04, 15), 125.87m, 3776.10m);
            Outing seedOuting6 = new Outing("Summer 2019", OutingType.Concert, 25, new DateTime(2019, 07, 15), 155.26m, 3881.50m);
            Outing seedOuting7 = new Outing("Summer 2020", OutingType.Golf, 40, new DateTime(2020, 07, 15), 35.56m, 1422.40m);
            Outing seedOuting8 = new Outing("Spring 2019", OutingType.Golf, 38, new DateTime(2019, 05, 10), 38.89m, 1477.82m);

            outingRepo.AddOutingToList(seedOuting1);
            outingRepo.AddOutingToList(seedOuting2);
            outingRepo.AddOutingToList(seedOuting3);
            outingRepo.AddOutingToList(seedOuting4);
            outingRepo.AddOutingToList(seedOuting5);
            outingRepo.AddOutingToList(seedOuting6);
            outingRepo.AddOutingToList(seedOuting7);
            outingRepo.AddOutingToList(seedOuting8);
        }
    }
}
