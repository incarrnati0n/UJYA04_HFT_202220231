using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UJYA04_HFT_20222023.Logic;
using UJYA04_HFT_20222023.Logic.LogicClasses;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        IManagersLogic logic;
        public ManagersController(IManagersLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Managers value)
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
