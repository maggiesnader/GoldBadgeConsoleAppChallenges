using Challenge1_POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1_Tests
{
    [TestClass]
    public class MenuItemPOCOTests
    {
        [TestMethod]
        public void SetMealName_ShouldSetCorrectString()
        {
            MenuItem meal = new MenuItem();
            meal.MealName = "Classic Burger";
            string expected = "Classic Burger";
            string actual = meal.MealName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealNumber_ShouldSetCorrectString()
        {
            MenuItem meal = new MenuItem();
            meal.MealNumber = "9";
            string expected = "9";
            string actual = meal.MealNumber;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealDescription_ShouldSetCorrectString()
        {
            MenuItem meal = new MenuItem();
            meal.MealDescription = "1/4lb Ground Chuck topped with cheddar cheese on a brioche bun, served with LTOPM.";
            string expected = "1/4lb Ground Chuck topped with cheddar cheese on a brioche bun, served with LTOPM.";
            string actual = meal.MealDescription;
            Assert.AreEqual(expected, actual);
        }
        public void SetMealIngredients_ShouldSetCorrectString()
        {
            MenuItem meal = new MenuItem();
            meal.MealIngredients = "Ground beef, herbs, cheddar cheese, flour, butter, vegetable oil, egg, salt, pepper, lettuce, tomato, onion, pickle, mayo";
            string expected = "Ground beef, herbs, cheddar cheese, flour, butter, vegetable oil, egg, salt, pepper, lettuce, tomato, onion, pickle, mayo";
            string actual = meal.MealIngredients;
            Assert.AreEqual(expected, actual);
        }
        public void SetMealPrice_ShouldSetCorrectDecimal()
        {
            MenuItem meal = new MenuItem();
            meal.MealPrice = 12.99m;
            decimal expected = 12.99m;
            decimal actual = meal.MealPrice;
            Assert.AreEqual(expected, actual);
        }

    }
}
