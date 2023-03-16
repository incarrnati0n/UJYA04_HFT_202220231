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
    public class ManagersController : ControllerBase
    {
        IManagersLogic logic;
        private readonly IHubContext<SignalRHub> hub;
        public ManagersController(IManagersLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Managers> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Managers Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Managers value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ManagersCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Managers value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ManagersUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var managerToDelete = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ManagersDeleted", managerToDelete);
        }
    }
}
