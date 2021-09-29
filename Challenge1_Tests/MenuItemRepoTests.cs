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

        //ADD METHOD    
        [TestMethod]
        public void AddMenuItemToList_MealIsNull_ReturnFalse()
        {
            //Arrange -- setting up the playing field
            MenuItem meal = null;
            MenuItemRepo repo = new MenuItemRepo();

            //act -- get/run the code we want to test
            bool result = repo.AddMenuItemToList(meal);

            //assert -- use the assert class to verify the expected outcome
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddMenuItemToList_MealIsNotNull_ReturnTrue()
        {
            //Arrange --
            MenuItem meal = new MenuItem("1", "Grilled Cheese", "Smoked Cheddar and Gouda cheese on Rye bread, served with a cup of Tomato Soup.", "Rye bread, cheddar cheese, gouda cheese, butter, tomato, herbs", 8.99m);
            MenuItemRepo repo = new MenuItemRepo();
            //Act --
            bool result = repo.AddMenuItemToList(meal);
            //Assert --
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GetByMealNumber_MealExists_ReturnMeal()
        {
            //Arrange
            string mealNumber = "5";
            //Act
            MenuItem result = _repo.ViewMealByNumber(mealNumber);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, mealNumber);
        }

        //GetbyMealNumber

        //update
        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue()
        {
            //arrange
            //testInitialize
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);

            //act
            bool updateResult = _repo.UpdateExistingMenuItem("5", newMeal);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("5", true)]
        [DataRow("9", false)]
        public void UpdateExistingMenuItem_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            //arrange
            //testInitialize
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);

            //act
            bool updateResult = _repo.UpdateExistingMenuItem(originalName, newMeal);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        //Delete
        [TestMethod]
        public void DeleteMenuAItem_ShouldReturnTrue()
        {
            //arrange
            MenuItem newMeal = new MenuItem("5", "Blueberry Scone", "Homemade scone filled with blueberries and ricotta cheese.", "Flour, Butter, Sugar, Salt, Cream, Egg, Blueberry, Ricotta, Cinnamon", 7.99m);
            //act
            bool deleteResult = _repo.RemoveMenuItem(newMeal.MealNumber);

            //asserty
            Assert.IsTrue(deleteResult);
        }
    }
}
