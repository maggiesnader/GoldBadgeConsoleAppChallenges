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
            //arrange
            MenuItem meal = new MenuItem();
            meal.MealName = "Classic Burger";
            //act
            string expected = "Classic Burger";
            string actual = meal.MealName;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
