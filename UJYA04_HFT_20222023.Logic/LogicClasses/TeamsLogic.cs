using System;
using System.Linq;
using UJYA04_HFT_20222023.Logic.LogicInterfaces;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    public class TeamsLogic : ITeamsLogic
    {
        IRepository<Teams> repo;

        public TeamsLogic(IRepository<Teams> repo)
        {
            this.repo = repo;
        }

        public void Create(Teams item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
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
            return repo.ReadAll();
        }

        public void Update(Teams item)
        {
            repo.Update(item);
        }



        public IQueryable<TeamInfo> AverageRatingInClub()
        {
            return repo
                .ReadAll()
                .Select(t => new TeamInfo()
                {
                    TeamName = t.TeamName,
                    AvgRating = t.Player.ToArray().Average(z => z.Rating)
                });


        }

    }
}
