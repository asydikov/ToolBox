using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToolBox.Services.Identity.Domain;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.EF
{
    public class IdentityDbContext : DbContext
    {
        private IOptions<SqlSettings> _sqlSettings;

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IOptions<SqlSettings> sqlSettings)
              : base(options)
        {
            _sqlSettings = sqlSettings;
            //https://github.com/Microsoft/mssql-docker/issues/360
            //  Database.EnsureCreatedAsync();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<User>().HasOne(x => x.RefreshToken)
                                        .WithOne(x => x.User)
                                        .HasForeignKey<RefreshToken>(x => x.UserId);

            modelBuilder.Seed();
        }

    }
}