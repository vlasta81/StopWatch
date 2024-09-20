using Microsoft.EntityFrameworkCore;
using StopWatch.Entities;

namespace StopWatch
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ChangeLog> ChangeLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string dbPath = Path.Combine(appDataPath, "ActivityMonitor", "ActivityMonitor.db");
            //if (!File.Exists(dbPath)) 
            //{
            //    File.Copy("ActivityMonitor.db", dbPath, true);
            //}
            //optionsBuilder.UseSqlite($"Data Source={dbPath}");
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
