using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.EF
{
    public class SQLMonitorDbContext : DbContext
    {
        private IOptions<SqlSettings> _sqlSettings;

        public SQLMonitorDbContext(DbContextOptions<SQLMonitorDbContext> options, IOptions<SqlSettings> sqlSettings)
              : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Database> Databases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<Server>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Server>().Property(x => x.Host).IsRequired();
            modelBuilder.Entity<Server>().Property(x => x.Port).IsRequired();
            modelBuilder.Entity<Server>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<Server>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<Server>().HasMany(x => x.Databases)
                                        .WithOne(x => x.Server);

            modelBuilder.Entity<Database>().Property(x => x.ServerId).IsRequired();
            modelBuilder.Entity<Database>().Property(x => x.Name).IsRequired();

            modelBuilder.Seed();
        }

    }
}