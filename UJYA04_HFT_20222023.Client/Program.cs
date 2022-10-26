using System;
using System.Linq;
using UJYA04_HFT_20222023.Repository;
using UJYA04_HFT_20222023.Models;
using System.Collections.Generic;

namespace UJYA04_HFT_20222023.Client
{
    internal class Program
    {

        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter player: ");
                string player = Console.ReadLine();
                rest.Post(new Players() { PlayerName = player}, "player");
            }
            else if (entity == "Team")
            {
                Console.WriteLine("Enter team: ");
                string team = Console.ReadLine();
                rest.Post(new Teams() { TeamName = team}, "team");
            }
            else
            {
                Console.WriteLine("Enter manager: ");
                string manager = Console.ReadLine();
                rest.Post(new Managers() { ManagerName = manager }, "manager");
            }
        }

        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Players> players = rest.Get<Players>("player");
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.PlayerId} : {player.PlayerName}");
                }
            }
            else if (entity == "Manager")
            {
                List<Managers> managers = rest.Get<Managers>("manager");
                foreach (var manager in managers)
                {
                    Console.WriteLine($"{manager.ManagerId} : {manager.ManagerName}");
                }
            }
            else
            {
                List<Teams> teams = rest.Get<Teams>("team");
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
                Players one = rest.Get<Players>(id, "actor");
                Console.Write($"New name [old: {one.PlayerName}]: ");
                string name = Console.ReadLine();
                one.PlayerName = name;
                rest.Put(one, "actor");
            }
            else if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Managers one = rest.Get<Managers>(id, "actor");
                Console.Write($"New name [old: {one.ManagerName}]: ");
                string name = Console.ReadLine();
                one.ManagerName = name;
                rest.Put(one, "actor");
            }
            else
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teams one = rest.Get<Teams>(id, "actor");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "actor");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
            else if (entity == "Manager")
            {
                Console.WriteLine("Enter Manager's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "manager");
            }
            else
            {
                Console.WriteLine("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "team");
            }
        }

        static void Main(string[] args)
        {
            //FootyDbContext ctx = new FootyDbContext();

            //var teams = ctx.Teams.ToList();
            //foreach (var team in teams)
            //{
            //    Console.WriteLine($"Team Name: {team.TeamName}, Stadium: {team.TeamStadiumName}");
            //}
            //var players = ctx.Players.ToList();
            //foreach (var player in players)
            //{
            //    Console.WriteLine($"Player Name: {player.PlayerName}, Rating: {player.Rating}");
            //}
            //var managers = ctx.Managers.ToList();
            //foreach (var manager in managers)
            //{
            //    Console.WriteLine($"Manager name: {manager.ManagerName}, Salary: {manager.ManagerSalary}");
            //}





        }
    }
}
