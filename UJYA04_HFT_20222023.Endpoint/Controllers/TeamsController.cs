using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using UJYA04_HFT_20222023.Endpoint.Services;
using UJYA04_HFT_20222023.Logic.LogicInterfaces;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeamsLogic logic;

        private readonly IHubContext<SignalRHub> hub;

        public TeamsController(ITeamsLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Teams> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Teams Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Teams value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("TeamsCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Teams value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("TeamsUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teamToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("TeamsDeleted", teamToDelete);
        }
    }
}
