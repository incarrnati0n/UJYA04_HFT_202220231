using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    internal class ManagersLogic
    {
        IRepository<Managers> repo;

        //CRUD methods


        public ManagersLogic(IRepository<Managers> repo)
        {
            this.repo = repo;
        }


        public void Create(Managers item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Managers Read(int id)
        {
            var managers = Read(id);
            if (managers == null)
            {
                throw new ArgumentException("This manager doesn't exist!");
            }
            return managers;
        }

        public IQueryable<Managers> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Managers item)
        {
            this.repo.Update(item);
        }

        //NON-CRUD methods

        public IQueryable<string> ManagerName(Teams team)
        {
            return this.repo
                .ReadAll()
                .Where(m => m.Team == team)
                .Select(m => m.ManagerName);
        }



    }
}
