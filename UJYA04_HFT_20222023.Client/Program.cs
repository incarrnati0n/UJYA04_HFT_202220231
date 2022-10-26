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
                Players one = rest.Get<Players>(id, "player");
                Console.Write($"New name [old: {one.PlayerName}]: ");
                string name = Console.ReadLine();
                one.PlayerName = name;
                rest.Put(one, "player");
            }
            else if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Managers one = rest.Get<Managers>(id, "manager");
                Console.Write($"New name [old: {one.ManagerName}]: ");
                string name = Console.ReadLine();
                one.ManagerName = name;
                rest.Put(one, "manager");
            }
            else
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teams one = rest.Get<Teams>(id, "team");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "team");
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

            rest = new RestService("http://localhost:65535", "team");

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

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Player", () => playerSubMenu.Show())
                .Add("Manager", () => managerSubMenu.Show())
                .Add("Team", () => teamSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
