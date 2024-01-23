using LR10_C121_GornakDmitrii;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Win()
        {
            // Arrange
            var teams = new Teams("Первая команда", "Вторая команда", DateTime.Parse("2005.04.12"),"Полуфинал", "Камп Ноу", "Открытый", "Победа");

            // Assert
            Assert.AreEqual(teams.TeamfirstPoints, 2);
            Assert.AreEqual(teams.TeamsecondPoints, 0);
        }

        [TestMethod]
        public void Loose()
        {
            // Arrange
            var teams = new Teams("Первая команда", "Вторая команда", DateTime.Parse("2005.04.12"), "Полуфинал", "Камп Ноу", "Открытый", "Поражение");

            // Assert
            Assert.AreEqual(teams.TeamfirstPoints, 0);
            Assert.AreEqual(teams.TeamsecondPoints, 2);
        }

        [TestMethod]
        public void Tie()
        {
            // Arrange
            var teams = new Teams("Первая команда", "Вторая команда", DateTime.Parse("2005.04.12"), "Полуфинал", "Камп Ноу", "Открытый", "Ничья");

            Assert.AreEqual(teams.TeamfirstPoints, 1);
            Assert.AreEqual(teams.TeamsecondPoints, 1);
        }
    }
}
