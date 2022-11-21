using System;
using System.Linq;
using UJYA04_HFT_20222023.Repository;
using UJYA04_HFT_20222023.Models;
using System.Collections.Generic;
using ConsoleTools;

namespace UJYA04_HFT_20222023.Client
{
    internal class Program
    {

        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter playername: ");
                string playername = Console.ReadLine();
                Console.WriteLine("Enter playernumber: ");
                int playernumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter playerage: ");
                int playerage = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter playerrating: ");
                int playerrating = int.Parse(Console.ReadLine());
                rest.Post(new Players() { PlayerName = playername, PlayerShirtNum = playernumber, PlayerAge = playerage, Rating = playerrating}, "players");
            }
            else if (entity == "Team")
            {
                Console.WriteLine("Enter teamname: ");
                string teamname = Console.ReadLine();
                Console.WriteLine("Enter teamowner: ");
                string teamowner = Console.ReadLine();
                Console.WriteLine("Enter teamfoundedyear: ");
                int teamfoundyear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter teamstadiumname: ");
                string teamstadiumname = Console.ReadLine();
                rest.Post(new Teams() { TeamName = teamname, TeamOwner = teamowner, TeamFoundedYear = teamfoundyear, TeamStadiumName = teamstadiumname}, "teams");
            }
            else
            {
                Console.WriteLine("Enter managername: ");
                string managername = Console.ReadLine();
                Console.WriteLine("Enter managerage: ");
                int managerage = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter managersalary(1000000, 5000000): ");
                double managermoney = double.Parse(Console.ReadLine());
                rest.Post(new Managers() { ManagerName = managername, ManagerAge=managerage,ManagerSalary=managermoney  }, "managers");
            }
        }

        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Players> players = rest.Get<Players>("players");
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.PlayerId} : {player.PlayerName}");
                }
            }
            else if (entity == "Manager")
            {
                List<Managers> managers = rest.Get<Managers>("managers");
                foreach (var manager in managers)
                {
                    Console.WriteLine($"{manager.ManagerId} : {manager.ManagerName}");
                }
            }
            else
            {
                List<Teams> teams = rest.Get<Teams>("teams");
                foreach (var team in teams)
                {
                    Console.WriteLine($"{team.TeamId} : {team.TeamName}");
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Players one = rest.Get<Players>(id, "players");
                Console.Write($"New name [old: {one.PlayerName}]: ");
                string name = Console.ReadLine();
                one.PlayerName = name;
                rest.Put(one, "players");
            }
            else if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Managers one = rest.Get<Managers>(id, "managers");
                Console.Write($"New name [old: {one.ManagerName}]: ");
                string name = Console.ReadLine();
                one.ManagerName = name;
                rest.Put(one, "managers");
            }
            else
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teams one = rest.Get<Teams>(id, "teams");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "teams");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "players");
            }
            else if (entity == "Manager")
            {
                Console.WriteLine("Enter Manager's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "managers");
            }
            else
            {
                Console.WriteLine("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "teams");
            }
        }

        static void AverageRatingInClub()
        {
            Console.WriteLine("Average rating in clubs");
            var clubs = rest.Get<TeamInfo>("stat/AverageRatingInClub");
            foreach (var item in clubs)
            {
                Console.WriteLine($"Team name: {item.TeamName} --- Average rating: {item.AvgRating}");
            }
            Console.ReadLine();
        }

        static void ManagerName()
        {
            Console.WriteLine("Team Id: ");
            int id = int.Parse(Console.ReadLine());

            var managers = rest.Get<string>($"stat/ManagerName/{id}");
            foreach (var manager in managers)
            {
                Console.WriteLine($"Manager name: {manager}");
            }
            Console.ReadLine();
        }

        static void TeamsOfPlayersUnder25()
        {
            var players = rest.Get<string>("stat/TeamsOfPlayersUnder25");
            foreach (var item in players)
            {
                Console.WriteLine($"TeamName: {item}");
            }
            Console.ReadLine();
        }

        static void ListPlayerByShirtNumber()
        {
            Console.WriteLine("Enter a shirtnumber: ");
            int number = int.Parse(Console.ReadLine());
            var info = rest.Get<Managers>($"stat/ListPlayerByShirtNumber/{number}");
            foreach (var item in info)
            {
                Console.WriteLine($"Team: {item.Team.TeamName}, Manager: {item.ManagerName}");
            }
            Console.ReadLine();
        }


        static void HighestRatingByTeamAndAge()
        {
            Console.WriteLine("Player age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Team name: ");
            string teamname = Console.ReadLine();
            var stuff = rest.Get<Players>($"stat/HighestRatingByTeamAndAge/{age},{teamname}");
            foreach (var item in stuff)
            {
                Console.WriteLine($"{item.PlayerName} --- {item.Rating}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            
            rest = new RestService("http://localhost:24518/", "Teams");
            
            var playerSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Player"))
               .Add("Create", () => Create("Player"))
               .Add("Delete", () => Delete("Player"))
               .Add("Update", () => Update("Player"))
               .Add("Exit", ConsoleMenu.Close);

            var managerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manager"))
                .Add("Create", () => Create("Manager"))
                .Add("Delete", () => Delete("Manager"))
                .Add("Update", () => Update("Manager"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ManagerName", () => ManagerName())
                .Add("AverageRatingInClub", () => AverageRatingInClub())
                .Add("TeamsOfPlayersUnder25", () => TeamsOfPlayersUnder25())
                .Add("HighestRatingByTeamAndAge", () => HighestRatingByTeamAndAge())
                .Add("TeamHasThatNumber", () => ListPlayerByShirtNumber())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Player", () => playerSubMenu.Show())
                .Add("Manager", () => managerSubMenu.Show())
                .Add("Team", () => teamSubMenu.Show())
                .Add("Non Cruds", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
