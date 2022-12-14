using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sport.Models;
using Sport.Models.Interfaces;
using System.Configuration;

namespace Sport.Data
{
    public class SportContext : DbContext
    {
        public DbSet<Club> Club { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Adress> Adress { get; set; }

        public SportContext(DbContextOptions<SportContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Sport; MultipleActiveResultSets=true; Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .Property(e => e.BirthDate).HasColumnType("date");


            modelBuilder.Entity<Coach>()
                .Property(e => e.BirthDate).HasColumnType("date");

            // Global turn off delete behaviour on foreign keys
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
