using System;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.EF
{
    public class IdentityDbContext : DbContext
    {
        private IServiceProvider _serviceProvider;

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IServiceProvider serviceProvider)
              : base(options)
        {
            _serviceProvider = serviceProvider;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<User>().HasOne(x => x.RefreshToken)
                                        .WithOne(x => x.User)
                                        .HasForeignKey<RefreshToken>(x => x.UserId);

            modelBuilder.Seed(_serviceProvider);
        }

    }
}