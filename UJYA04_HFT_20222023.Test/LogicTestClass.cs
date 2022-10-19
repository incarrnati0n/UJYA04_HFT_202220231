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

        Mock<IRepository<Players>> mockPlayersRepository;

        [SetUp]
        public void Init()
        {
            var input = new List<Players>()
            {
                new Players("1#1#Mason Mount#19#23#84"),
                new Players("2#2#Oliver Giroud#9#36#79"),
                new Players("3#3#Joshua Kimmich#6#27#89"),
                new Players("4#1#Cesar Azpilicueta#28#33#83"),
                new Players("5#1#Kai Havertz#29#23#84"),
                new Players("6#1#Kepa Arrizabalaga#1#28#80"),
                new Players("7#2#Rafael Leao#17#23#84"),
            }.AsQueryable();

            mockPlayersRepository = new Mock<IRepository<Players>>();
            mockPlayersRepository.Setup(p => p.ReadAll()).Returns(input);
            playersLogic = new PlayersLogic(mockPlayersRepository.Object);
        }


        [Test]




    }
}
