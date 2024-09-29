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
    public class TrophyTests
    {
        [TestMethod()]
        public void TrophyNullCompetitionTest()
        {
            //test: Null
            //arrange: 
            Trophy TrophyNullCompetition = new Trophy
            {
                Id = 1,
                Competition = null,
                Year = 1990
            };
            //act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => TrophyNullCompetition.ValidateCompetition());
        }

        [TestMethod()]
        public void TrophyEmptyCompeitionTest()
        {
            //test: Empty
            //arrange
            Trophy trophyEmptyCompetition = new Trophy()
            {
                Id = 3,
                Competition = "",
                Year = 2001
            };
            //assert & act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyEmptyCompetition.ValidateCompetition());
        }



        [TestMethod()]
        public void TrophyIncorrectLengthCompetitionTest()
        {

            //test: Incorrect length
            //arrange
            Trophy TrophyIncorrectLengthCompetitiontest = new Trophy()
            {
                Id = 2,
                Competition = "ab",
                Year = 2000
            };
            //assert & act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyIncorrectLengthCompetitiontest.ValidateCompetition());
        }

        [TestMethod()]
        public void TrophyCorrectLegnthCompetitionTest()
        {
            //test: correct Length 
            Trophy trophyCorrectLengeth = new Trophy()
            {
                Competition = "abc",
                Year = 2021
            };
            //act
            Assert.AreEqual(3, trophyCorrectLengeth.Competition.Length);
        }

        [TestMethod()]
        public void TrophyInvalidDateTest()
        {
            //test: TrophyBeforeYear1970
            //arrange
            Trophy TrophyInvalidDateTest = new Trophy()
            {
                Id = 3,
                Competition = "Olympics1",
                Year = 1969,
            };
            //assert & act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyInvalidDateTest.ValidateYear());
        }

        [TestMethod()]
        public void TrophyInvalidDateTest1()
        {
            //test: TrophyAfterYear2024
            //arrange
            Trophy TrophyInvalidDateTest1 = new Trophy()
            {
                Id = 3,
                Competition = "Oplymics2",
                Year = 2025,
            };
            //assert & act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyInvalidDateTest1.ValidateYear());
        }

        [TestMethod()]
        public void TrophyCorrectYearTest()
        {
            //test: TrophyBetweenYear1970 and 2024
            //arrange
            Trophy TrophyCorrectYearTest = new Trophy()
            {
                Id = 3,
                Competition = "Oplymics2",
                Year = 2024,
            };
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //arrange
            Trophy trophy1 = new Trophy()
            {
                Id = 1,
                Competition = "Olympics",
                Year = 2023
            };

            //act
            string result = trophy1.ToString();

            //assert
            Assert.AreEqual("Trophy ID: 1, Competition: Olympics, Year: 2023", result);
        }
    }
}