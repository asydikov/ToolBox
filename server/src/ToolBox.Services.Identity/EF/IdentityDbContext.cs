using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.EF
{
    public class IdentityDbContext : DbContext
    {
        // private IOptions<SqlSettings> _sqlSettings;
        private IOptions<SqlSettings> _sqlSettings;

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IOptions<SqlSettings> sqlSettings)
              : base(options)
        {
            _sqlSettings = sqlSettings;
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).IsRequired();
            modelBuilder.Seed();
        }
    }
}