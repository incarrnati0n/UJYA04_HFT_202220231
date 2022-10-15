using Microsoft.EntityFrameworkCore;
using System;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Repository
{
    public class FootyDbContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Managers> Managers { get; set; }

        public FootyDbContext()
        {
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\imcon\Desktop\Egyetem folder\HFT\UJYA04_HFT_20222023\UJYA04_HFT_20222023.Repository\FootyDb.mdf;Integrated Security = True;MultipleActiveResultSets = True";

                optionsBuilder
                .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>(team => team
            .HasOne(team => team.Manager)
            .WithOne(manager => manager.Team)
            .HasForeignKey<Teams>(team => team.ManagerId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Players>(player => player
            .HasOne(player => player.Team)
            .WithMany(team => team.Player)
            .HasForeignKey(player => player.TeamId)
            .OnDelete(DeleteBehavior.Cascade));

            





        }




    }
}
