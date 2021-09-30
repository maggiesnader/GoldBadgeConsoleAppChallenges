using Challenge4_POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge4_Tests
{
    [TestClass]
    public class OutingPOCOTests
    {
        [TestMethod]
        public void SetOutingTitle_ShouldSetCorrectString()
        {
            Outing outing = new Outing();
            outing.OutingTitle = "Winter Holiday 2020";
            string expected = "Winter Holiday 2020";
            string actual = outing.OutingTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetOutingID_ShouldSetCorrectInt()
        {
            Outing outing = new Outing();
            outing.ID = 1;
            int expected = 1;
            int actual = outing.ID;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetOutingType_ShouldSetCorrectOutingType()
        {
            Outing outing = new Outing();
            outing.TypeOfOuting = OutingType.Golf;
            OutingType expected = OutingType.Golf;
            OutingType actual = outing.TypeOfOuting;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetDateOfOuting_ShouldSetCorrectDateTime()
        {
            Outing outing = new Outing();
            outing.OutingDate = new DateTime(2020, 12, 18);
            DateTime expected = new DateTime(2020, 12, 18);
            DateTime actual = outing.OutingDate;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetNumberOfAttendees_ShouldSetCorrectInt()
        {
            Outing outing = new Outing();
            outing.NumberOfAttendees = 25;
            int expected = 25;
            int actual = outing.NumberOfAttendees;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetCostPerPerson_ShouldSetCorrectDecimal()
        {
            Outing outing = new Outing();
            outing.CostPerPerson = 59.23m;
            decimal expected = 59.23m;
            decimal actual = outing.CostPerPerson;
            Assert.AreEqual(expected, actual);
        }
        public void SetTotalCost_ShouldSetCorrectDecimal()
        {
            Outing outing = new Outing();
            outing.TotalCost = 1480.75m;
            decimal expected = 1480.75m;
            decimal actual = outing.TotalCost;
            Assert.AreEqual(expected, actual);
        }
    }
}
