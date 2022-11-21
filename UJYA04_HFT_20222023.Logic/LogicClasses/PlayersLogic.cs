using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    public class PlayersLogic : IPlayersLogic
    {
        IRepository<Players> repo;

        public PlayersLogic(IRepository<Players> repo)
        {
            this.repo = repo;
        }

        public void Create(Players item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Players Read(int id)
        {
            var players = repo.Read(id);
            if (players == null)
            {
                throw new ArgumentException("The player doesn't exist");
            }
            return players;
        }

        public IQueryable<Players> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Players item)
        {
            this.repo.Update(item);
        }



        public IQueryable<Managers> ListPlayerByShirtNumber(int shirtnumber)
        {
            return this.repo
                .ReadAll()
                .Where(p => p.PlayerShirtNum == shirtnumber)
                .Select(p => p.Team.Manager)
                .Distinct();
        }



        public IQueryable<string> TeamsOfPlayersUnder25()
        {
            return this.repo
                .ReadAll()
                .Where(p => p.PlayerAge < 25)
                .Select(p => p.Team.TeamName)
                .Distinct();
        }



        public IQueryable<Players> HighestRatingByTeamAndAge(int age, string teamname)
        {
            return this.repo
                .ReadAll()
                .Where(p => p.PlayerAge == age && p.Team.TeamName == teamname)
                .OrderByDescending(p => p.Rating)
                .Take(1);
        }
    }
}
