using UJYA04_HFT_20222023.Logic;
using UJYA04_HFT_20222023.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UJYA04_HFT_20222023.Logic.LogicClasses;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        IPlayersLogic logic;
        public PlayersController(IPlayersLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Players value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
