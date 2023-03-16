using UJYA04_HFT_20222023.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UJYA04_HFT_20222023.Logic.LogicInterfaces;
using Microsoft.AspNetCore.SignalR;
using UJYA04_HFT_20222023.Endpoint.Services;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        IPlayersLogic logic;

        private readonly IHubContext<SignalRHub> hub;

        public PlayersController(IPlayersLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Players> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Players Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Players value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("PlayersCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Players value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PlayersUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var playerToDelete = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PlayersDeleted", playerToDelete);
        }
    }
}
