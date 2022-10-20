using NUnit.Framework;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;
using UJYA04_HFT_20222023.Logic;
using System;
using UJYA04_HFT_20222023.Logic.LogicClasses;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UJYA04_HFT_20222023.Test
{
    [TestFixture]
    public class LogicTestClass
    {

        private PlayersLogic playersLogic;
        private ManagersLogic managersLogic;
        private TeamsLogic teamsLogic;

        Mock<IRepository<Players>> mockPlayersRepository;
        Mock<IRepository<Managers>> mockManagersRepository;
        Mock<IRepository<Teams>> mockTeamsRepository;

        [SetUp]
        public void Init()
        {
            var inputPlayers = new List<Players>()
            {
                new Players("1#1#Mason Mount#19#23#84"),
                new Players("2#2#Oliver Giroud#9#36#79"),
                new Players("3#3#Joshua Kimmich#6#27#89"),
                new Players("4#1#Cesar Azpilicueta#28#33#83"),
                new Players("5#1#Kai Havertz#29#23#84"),
                new Players("6#1#Kepa Arrizabalaga#1#28#80"),
                new Players("7#2#Rafael Leao#17#23#84"),
            }.AsQueryable();

            var inputManagers = new List<Managers>()
            {
                new Managers("1#1#Graham Potter#47#2150000"),
                new Managers("2#2#Stefano Pioli#56#3700000"),
                new Managers("3#3#Julian Nagelsmann#35#2400000"),
            }.AsQueryable();


            var inputTeams = new List<Teams>()
            {
                new Teams("1#1#Chelsea FC#Todd Boehly#1905#Stanford Bridge"),
                new Teams("2#2#AC Milan#RedBird Capital Partners LLC#1899#San Siro"),
                new Teams("3#3#FC Bayern München#Herbert Hainer#1900#Allianz Arena")
            }.AsQueryable();

            mockPlayersRepository = new Mock<IRepository<Players>>();
            mockPlayersRepository.Setup(p => p.ReadAll()).Returns(inputPlayers);
            playersLogic = new PlayersLogic(mockPlayersRepository.Object);

            mockManagersRepository = new Mock<IRepository<Managers>>();
            mockManagersRepository.Setup(m => m.ReadAll()).Returns(inputManagers);
            managersLogic = new ManagersLogic(mockManagersRepository.Object);

            mockTeamsRepository = new Mock<IRepository<Teams>>();
            mockTeamsRepository.Setup(t => t.ReadAll()).Returns(inputTeams);
            teamsLogic = new TeamsLogic(mockTeamsRepository.Object);
        }

        [Test]
        public void TeamCreate()
        {
            Assert.That(() => teamsLogic.Create(new Teams("6#6#Real Madrid#Florentino Perez#1902#Santiago Bernabeu")), Throws.Nothing);
        }

        [Test]
        public void ManagerCreate()
        {
            Assert.That(() => managersLogic.Create(new Managers("6#6#Carlo Ancelotti#63#5000000")), Throws.Nothing);
        }

        [Test]
        public void PlayerCreate()
        {
            Assert.That(() => playersLogic.Create(new Players("16#6#Eden Hazard#7#33#84")), Throws.Nothing);
        }

        [Test]
        public void ManagerNameTest()
        {
            Assert.That(() => managersLogic.ManagerName(2),Throws.Nothing);
        }

        [Test]
        public void ListPlayerByShirtNumberTest()
        {
            Assert.That(() => playersLogic.ListPlayerByShirtNumber(1), Throws.Nothing);
        }

        [Test]
        public void TeamsOfPlayersUnder25Test()
        {
            Assert.That(() => playersLogic.TeamsOfPlayersUnder25(), Throws.Nothing);
        }

        [Test]
        public void HighestRatingByTeamAndAgeTest()
        {
            Assert.That(() => playersLogic.HighestRatingByTeamAndAge(23, "Chelsea FC"), Throws.Nothing);
        }

        [Test]
        public void AverageRatingInClubTest()
        {
            Assert.That(() => teamsLogic.AverageRatingInClub(), Throws.Nothing);
        }

        [Test]
        public void PlayerDelete()
        {
            Assert.That(() => playersLogic.Delete(4), Throws.Nothing);
        }

        [Test]
        public void ManagerDelete()
        {
            Assert.That(() => managersLogic.Delete(3), Throws.Nothing);
        }


    }
}
