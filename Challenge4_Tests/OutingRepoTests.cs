using Challenge4_POCO;
using Challenge4_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge4_Tests
{
    [TestClass]
    public class OutingRepoTests
    {
        private OutingRepo _repo = new OutingRepo();

        [TestInitialize]
        public void Arrange()
        {
            Outing outing = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 59.23m, 1480.75m);
            _repo.AddOutingToList(outing);
        }

        [TestMethod]
        public void AddOutingToList_OutingIsNotNull_ReturnTrue()
        {
            Outing outing = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 59.23m, 1480.75m);
            OutingRepo repo = new OutingRepo();
            bool outingResult = repo.AddOutingToList(outing);
            Assert.IsTrue(outingResult);
        }

        [TestMethod]
        public void AddOutingToList_OutingIsNull_ReturnFalse()
        {
            Outing outing = null;
            OutingRepo repo = new OutingRepo();
            bool outingResult = repo.AddOutingToList(outing);
            Assert.IsFalse(outingResult);
        }


        [TestMethod]
        public void ViewOutingById_OutingExists_ReturnOuting()
        {
            int id = 1;
            Outing outingResult = _repo.ViewOutingByID(id);
            Assert.IsNotNull(outingResult);
            Assert.AreEqual(outingResult.ID, id);
        }

        [TestMethod]
        public void ViewOutingById_OutingDoesNotExist_ReturnNull()
        {
            int id = 0;
            Outing outingResult = _repo.ViewOutingByID(id);
            Assert.IsNull(outingResult);
        }

        [TestMethod]
        public void ViewOutingByType_OutingDoesNotExist_ReturnNull()
        {
            OutingType typeOfOuting = OutingType.Golf;
            Outing outingResult = _repo.ViewOutingByType(typeOfOuting);
            Assert.IsNull(outingResult);
        }

        [TestMethod]
        public void GetOutingCostTotalByType_OutingTypeExists_ReturnTrue()
        {
            OutingType typeOfOuting = OutingType.Bowling;
            OutingRepo repo = new OutingRepo();
            bool outingResult = repo.GetOutingCostTotalByType(typeOfOuting);
            Assert.IsTrue(outingResult);
        }

        [TestMethod]
        public void GetTotalCostOfAllOutings_OutingsExist_ReturnTrue()
        {
            //Outing outing = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 59.23m, 1480.75m);
            OutingRepo _repo = new OutingRepo();
            List<Outing> _List = new List<Outing>();

            bool outingResult = _repo.GetTotalCostOfAllOutings(_List);
            Assert.IsTrue(outingResult);
        }

        [TestMethod]
        public void UpdateExistingOuting_ShouldReturnTrue()
        {
            Outing outing = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 79.23m, 1980.75m);
            bool updateResult = _repo.UpdateExistingOuting(1, outing);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(5, false)]
        public void UpdateExistingOuting_ShouldMatchGivenBool(int id, bool shouldUpdate)
        {
            Outing outing = new Outing("Winter Holiday 2020", OutingType.Bowling, 25, new DateTime(2020, 12, 18), 79.23m, 1980.75m);
            bool updateResult = _repo.UpdateExistingOuting(id, outing);
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteOuting_ShouldReturnTrue()
        {
            int id = 1;
            bool deleteResult = _repo.RemoveOutingFromInventory(id);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void DeleteOuting_ShouldReturnFalse()
        {
            Outing outing = new Outing();
            bool deleteResult = _repo.RemoveOutingFromInventory(outing.ID);
            Assert.IsFalse(deleteResult);
        }

    }
}
