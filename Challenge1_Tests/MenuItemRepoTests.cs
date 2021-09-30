using Challenge1_POCO;
using Challenge1_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1_Tests
{
    [TestClass]
    public class MenuItemRepoTests
    {
        private MenuItemRepo _repo = new MenuItemRepo();

        [TestInitialize]
        public void Arrange()
        {
            MenuItem meal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta", 6.99m);
            _repo.AddMenuItemToList(meal);
        }

        [TestMethod]
        public void AddMenuItemToList_MealIsNull_ReturnFalse()
        {
            MenuItem meal = null;
            MenuItemRepo repo = new MenuItemRepo();

            bool result = repo.AddMenuItemToList(meal);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddMenuItemToList_MealIsNotNull_ReturnTrue()
        {
            MenuItem meal = new MenuItem("1", "Grilled Cheese", "Smoked Cheddar and Gouda cheese on Rye bread, served with a cup of Tomato Soup.", "Rye bread, cheddar cheese, gouda cheese, butter, tomato, herbs", 8.99m);
            MenuItemRepo repo = new MenuItemRepo();
            
            bool result = repo.AddMenuItemToList(meal);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ViewByMealNumber_MealExists_ReturnMeal()
        {
            string mealNumber = "5";
            
            MenuItem result = _repo.ViewMealByNumber(mealNumber);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, mealNumber);
        }
        [TestMethod]
        public void ViewByMealNumber_MealDoesNotExist_ReturnNull()
        {
            string mealNumber = null;
            MenuItem result = _repo.ViewMealByNumber(mealNumber);
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue()
        {
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);

            bool updateResult = _repo.UpdateExistingMenuItem("5", newMeal);

            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("5", true)]
        [DataRow("9", false)]
        public void UpdateExistingMenuItem_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);

            bool updateResult = _repo.UpdateExistingMenuItem(originalName, newMeal);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);
            
            bool deleteResult = _repo.RemoveMenuItem(newMeal.MealNumber);

            Assert.IsTrue(deleteResult);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnFalse()
        {
            MenuItem newMeal = new MenuItem();
            bool deleteResult = _repo.RemoveMenuItem(newMeal.MealNumber);
            Assert.IsFalse(deleteResult);
        }
    }
}
