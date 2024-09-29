using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTrophy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTrophy.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests1
    {
        private TrophiesRepositoryLib _repository;
        public TrophiesRepositoryTests1()
        {
            _repository = new TrophiesRepositoryLib();
        }

        private readonly Trophy _trophy = new() { Competition = "FraOlympics", Year = 1980 };


        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Trophy> trophies = _repository.Get();
            Assert.AreEqual(5, trophies.Count());
            Assert.AreEqual(trophies.First().Competition, "OlympicsFra");

            IEnumerable<Trophy> sortedTrophies  = _repository.Get(sortBy: "compeition");
            Assert.AreEqual(sortedTrophies.First().Competition, "OlympicsFra");

            IEnumerable<Trophy> sortedTrophies2 = _repository.Get(sortBy: "year");
            Assert.AreEqual(sortedTrophies.First().Competition, "OlympicsFra");
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repository.GetById(1));
            Assert.IsNull(_repository.GetById(100));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.IsNull(_repository.Remove(100));
            Assert.AreEqual(1, _repository.Remove(1)?.Id);
            Assert.AreEqual(4, _repository.Get().Count());
        }  
    }
}