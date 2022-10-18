using System;
using System.Linq;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Logic
{
    public class TeamsLogic
    {
        IRepository<Teams> repo;


        //CRUD methods

        public TeamsLogic(IRepository<Teams> repo)
        {
            this.repo = repo;
        }

        public void Create(Teams item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Teams Read(int id)
        {
            var team = repo.Read(id);
            if (team == null)
            {
                throw new ArgumentException("The team doesn't exist!");
            }
            return team;
        }

        public IQueryable<Teams> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Teams item)
        {
            this.repo.Update(item);
        }

        //Non-CRUD methods

        public IQueryable<double> AverageRatingInClub()
        {
            return this.repo
                .ReadAll()
                .Select(t => t.Player.ToArray().Average(t => t.Rating));

        }
    }
}
