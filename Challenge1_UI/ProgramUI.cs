using Challenge1_POCO;
using Challenge1_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_UI
{
    class ProgramUI
    {
        private MenuItemRepo _menuItemRepo = new MenuItemRepo();
        public void Run()
        {
            SeedMealList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                DisplayMenu();
                MenuOptions();
            }
        }
        private void DisplayMenu()
        {
            Console.WriteLine("Komodo Cafe\n" +
                "Select a Menu Option:\n" +
                "1. View All Meals\n" +
                "2. View Meal by Meal Number\n" +
                "3. Add Meal\n" +
                "4. Delete Meal\n" +
                "5. Exit");
        }
        private void MenuOptions()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    DisplayAllMeals();
                    break;
                case "2":
                    DisplayByMealNumber();
                    break;
                case "3":
                    //
                    break;
                case "4":
                    //
                    break;
                case "5":
                    //
                    break;
            }
        }

        // 1. View all meals
        private void DisplayAllMeals()
        {
            Console.Clear();
            List<MenuItem> listOfMeals = _menuItemRepo.ViewAllMeals();
            foreach(MenuItem meal in listOfMeals)
            {
                Console.WriteLine($"\n{meal.MealNumber}. {meal.MealName}:\n" +
                    $"{meal.MealDescription}\n");
            }
        }

        // 2. view meal by number
        private void DisplayByMealNumber()
        {
            Console.Clear();
            //get #
            Console.WriteLine("Enter a Meal Number to see its full details:");
            int mealNumber = int.Parse(Console.ReadLine());
            MenuItem meal = _menuItemRepo.ViewMealByNumber(mealNumber);
            //display
            if(meal != null)
            {
                Console.WriteLine($"\n{meal.MealNumber}. {meal.MealName}:\n" +
                    $"\t${meal.MealPrice}\n" +
                    $"\t{meal.MealDescription}\n" +
                    $"\t\tIngredients: {meal.MealIngredients}\n");
            }
            else
            {
                Console.WriteLine("No meal with that number. Try Again...");
            }
        }

        // 3. create meal
        private void CreateNewMeal()
        {
            Console.Clear();
            MenuItem newMeal = new MenuItem();

        }

        // 4. Delete meal
        // 5. Exit

        //SEED MEALS
        

    }
}
