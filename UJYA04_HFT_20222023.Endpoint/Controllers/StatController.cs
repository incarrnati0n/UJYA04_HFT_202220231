using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UJYA04_HFT_20222023.Logic;
using UJYA04_HFT_20222023.Logic.LogicClasses;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    public class StatController : ControllerBase
    {
        ITeamsLogic teamsLogic { get; set; }
        IManagersLogic managersLogic { get; set; }
        IPlayersLogic playersLogic { get; set; }

        public StatController(ITeamsLogic teamsLogic, IManagersLogic managersLogic, IPlayersLogic playersLogic)
        {
            this.teamsLogic = teamsLogic;
            this.managersLogic = managersLogic;
            this.playersLogic = playersLogic;
        }

        [HttpGet]
        public IEnumerable<TeamInfo> AverageRatingInClub()
        {
            return this.teamsLogic.AverageRatingInClub();
        }

        [HttpGet("{id}")]
        public IEnumerable<string> ManagerName(int id)
        {
            return this.managersLogic.ManagerName(id);
        }

        [HttpGet("{shirtnumber}")]
        public IEnumerable<Managers> ListPlayerByShirtNumber(int shirtnumber)
        {
            return this.playersLogic.ListPlayerByShirtNumber(shirtnumber);
        }

        [HttpGet]
        public IEnumerable<string> TeamsOfPlayersUnder25()
        {
            return this.playersLogic.TeamsOfPlayersUnder25();
        }

        [HttpGet("{age, teamname}")]
        public IEnumerable<Players> HighestRatingByTeamAndAge(int age, string teamname)
        {
            return this.playersLogic.HighestRatingByTeamAndAge(age, teamname);
        }


    }
}
