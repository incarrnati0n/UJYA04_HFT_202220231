using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UJYA04_HFT_20222023.Logic.LogicInterfaces;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeamsLogic logic;
        public TeamsController(ITeamsLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Teams value)
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
