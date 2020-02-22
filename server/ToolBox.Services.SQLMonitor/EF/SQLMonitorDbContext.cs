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

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();
        }

    }
}