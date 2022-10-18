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
                //string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\imcon\Desktop\Egyetem folder\HFT\UJYA04_HFT_20222023\UJYA04_HFT_20222023.Repository
                //\FooballDb.mdf; Integrated Security = True;MultipleActiveResultSets=True";

                optionsBuilder
                //.UseSqlServer(conn)
                .UseInMemoryDatabase("FootyDatabase")
                .UseLazyLoadingProxies();
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
                new Teams("3#3#FC Bayern München#Herbert Hainer#1900#Allianz Arena"),
                new Teams("4#4#SSC Napoli#Filmauro#1926#San Paolo Stadion"),
                new Teams("5#5#Brighton and Hove Albion#Tony Bloom#1901#America Express Community Stadium")
            });

            modelBuilder.Entity<Managers>().HasData(new Managers[]
            {
                new Managers("1#1#Graham Potter#47#2150000"),
                new Managers("2#2#Stefano Pioli#56#3700000"),
                new Managers("3#3#Julian Nagelsmann#35#2400000"),
                new Managers("4#4#Luciano Spaletti#63#3000000"),
                new Managers("5#5#Roberto de Zerbi#43#2000000")
            });


            modelBuilder.Entity<Players>().HasData(new Players[]
            {
                new Players("1#1#Mason Mount#19#23#84"),
                new Players("2#2#Oliver Giroud#9#36#79"),
                new Players("3#3#Joshua Kimmich#6#27#89"),
                new Players("4#1#Cesar Azpilicueta#28#33#83"),
                new Players("5#1#Kai Havertz#29#23#84"),
                new Players("6#1#Kepa Arrizabalaga#1#28#80"),
                new Players("7#2#Rafael Leao#17#23#84"),
                new Players("8#2#Davide Calabria#2#25#80"),
                new Players("9#2#Mike Maignan#1#27#87"),
                new Players("10#3#Leon Goretzka#8#27#87"),
                new Players("11#3#Manuel Neuer#1#36#90"),
                new Players("12#3#Thomas Müller#25#33#87"),
                new Players("13#4#Alex Meret#1#25#78"),
                new Players("14#4#Victor Osimhen#9#23#83"),
                new Players("15#4#Khvicha Kvaratskhelia#77#21#74"),
                new Players("16#4#Mario Rui#6#31#78"),
                new Players("17#5#Robert Sanchez#1#24#77"),
                new Players("18#5#Leandro Trossard#11#27#79"),
                new Players("20#5#Alexis MacAllister#10#23#76"),
                new Players("21#5#Solly March#7#28#75"),
            });
        }
    }
}
