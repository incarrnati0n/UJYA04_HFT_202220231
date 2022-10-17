using System;
using System.Linq;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Client
{
    internal class Program
    {
        //TODO lazy loading teljes megírása, illetve IRepository interface és model osztályokban a repository classest megcsinálni


        static void Main(string[] args)
        {
            FootyDbContext ctx = new FootyDbContext();

            var teams = ctx.Teams.ToList();
            foreach (var team in teams)
            {
                Console.WriteLine($"Team Name: {team.TeamName}, Stadium: {team.TeamStadiumName}");
            }
            var players = ctx.Players.ToList();
            foreach (var player in players)
            {
                Console.WriteLine($"Player Name: {player.PlayerName}, Rating: {player.Rating}");
            }
            var managers = ctx.Managers.ToList();
            foreach (var manager in managers)
            {
                Console.WriteLine($"Manager name: {manager.ManagerName}, Salary: {manager.ManagerSalary}");
            }


        }
    }
}
