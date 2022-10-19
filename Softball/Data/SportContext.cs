using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sport.Models;
using Sport.Models.Interfaces;

namespace Sport.Data
{
    public class SportContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Game> Games { get; set; }

        public SportContext(DbContextOptions<SportContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Data/Sport.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .Property(e => e.BirthDate).HasColumnType("date");


            modelBuilder.Entity<Coach>()
                .Property(e => e.BirthDate).HasColumnType("date");
        }

    }
}
