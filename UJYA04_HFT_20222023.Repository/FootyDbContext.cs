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
                string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\imcon\Desktop\Egyetem folder\HFT\UJYA04_HFT_20222023\UJYA04_HFT_20222023.Repository\FooballDb.mdf; Integrated Security = True;MultipleActiveResultSets=True";

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

            modelBuilder.Entity<Teams>().HasData(new Teams[]
            {
                new Teams("1#1#Chelsea FC#Todd Boehly#1905#Stanford Bridge"),
                new Teams("2#2#AC Milan#RedBird Capital Partners LLC#1899#San Siro"),
                new Teams("3#3#FC Bayern München#Herbert Hainer#1900#Allianz Arena")
            });

            modelBuilder.Entity<Managers>().HasData(new Managers[]
            {
                new Managers("1#1#Graham Potter#47#2150000"),
                new Managers("2#2#Stefano Pioli#56#3700000"),
                new Managers("3#3#Julian Nagelsmann#35#2400000")
            });


            modelBuilder.Entity<Players>().HasData(new Players[]
            {
                new Players("1#1#Mason Mount#19#23#84"),
                new Players("2#2#Oliver Giroud#9#36#79"),
                new Players("3#3#Joshua Kimmich#6#27#89")
            });
        }
    }
}
