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
            SeedMeals();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Komodo Cafe\n" +
                "Select a Menu Option:\n" +
                "1. View All Meals\n" +
                "2. View Meal by Meal Number\n" +
                "3. Add Meal\n" +
                "4. Delete Meal\n" +
                "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        DisplayAllMeals();
                        Console.Clear();
                        break;
                    case "2":
                        DisplayByMealNumber();
                        Console.Clear();
                        break;
                    case "3":
                        CreateNewMeal();
                        Console.Clear();
                        break;
                    case "4":
                        DeleteMeal();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        keepRunning = false;
                        break;
                }
            }
        }
        private void DisplayAllMeals()
        {
            Console.Clear();
            List<MenuItem> listOfMeals = _menuItemRepo.ViewAllMeals();
            foreach(MenuItem meal in listOfMeals)
            {
                Console.WriteLine($"\n{meal.MealNumber}. {meal.MealName}:\n" +
                    $"{meal.MealDescription}\n");
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
        }
        private void DisplayByMealNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter a Meal Number to see its full details:");
            string mealNumber = Console.ReadLine();
            MenuItem meal = _menuItemRepo.ViewMealByNumber(mealNumber);
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

            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
        }
        private void CreateNewMeal()
        {
            Console.Clear();
            MenuItem newMeal = new MenuItem();
            Console.WriteLine("\nEnter the new Meal's number (1, 2, 3):\n");
            newMeal.MealNumber = Console.ReadLine();
            Console.WriteLine("\nEnter the new Meal's name:\n");
            newMeal.MealName = Console.ReadLine();
            Console.WriteLine("\nEnter the new Meal's description:\n");
            newMeal.MealDescription = Console.ReadLine();
            Console.WriteLine("\nEnter the new Meal's list of ingredients:\n");
            newMeal.MealIngredients = Console.ReadLine();
            Console.WriteLine("\nEnter the price of the new Meal (12.99, 9.87, 5.00):\n");
            newMeal.MealPrice = decimal.Parse(Console.ReadLine());

            _menuItemRepo.AddMenuItemToList(newMeal);

            Console.WriteLine("\nUpdate Complete. Press any key to continue:");
            Console.ReadKey();
        }
        private void DeleteMeal()
        {
            Console.Clear();
            DisplayAllMeals();
            Console.WriteLine("Enter the Meal Number of the meal you would like to delete:\n");
            string userInput = Console.ReadLine();

            bool wasDeleted = _menuItemRepo.RemoveMenuItem(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted.");
            }
        }
        private void SeedMeals()
        {
            MenuItem seedMeal1 = new MenuItem("1", "Grilled Cheese", "Smoked Cheddar and Gouda cheese on Rye bread, served with a cup of Tomato Soup.", "Rye bread, cheddar cheese, gouda cheese, butter, tomato, herbs", 8.99m);
            MenuItem seedMeal2 = new MenuItem("2", "Ham and Cheese Croissant", "Homemade croissant with sliced ham, swiss cheese, and horseradish mustard", "Wheeat Flour, Butter, Smoked Ham, Salt, Egg, Swiss Cheese, Horseradish Mustard", 7.99m);
            _menuItemRepo.AddMenuItemToList(seedMeal1);
            _menuItemRepo.AddMenuItemToList(seedMeal2);
        }
    }
}
