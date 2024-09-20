using Microsoft.EntityFrameworkCore;
using StopWatch.Entities;

namespace StopWatch
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ChangeLog> ChangeLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=StopWatch.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeLog>()
                .Property(c => c.Type)
                .HasConversion<string>();
        }

    }
}
