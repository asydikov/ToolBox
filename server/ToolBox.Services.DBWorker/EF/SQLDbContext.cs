using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.Entities;

namespace ToolBox.Services.DBWorker.EF
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }
        public DbSet<DatabaseNameSP> DatabaseNames { set; get; }
        public DbSet<DatabaseSpace> Space { set; get; }
        public DbSet<User> User { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseSpace>().HasKey("DatabaseName");
            modelBuilder.Entity<DatabaseSpace>().Property("DatabaseName").HasColumnName("database_name");
            modelBuilder.Entity<DatabaseSpace>().Property("DatabaseSize").HasColumnName("database_size");
            //modelBuilder.Entity<DatabaseSpace>().Property("UnallocatedSpace").HasColumnName("unallocated_space");
            modelBuilder.Entity<DatabaseSpace>().Property("Reserved").HasColumnName("reserved");
            modelBuilder.Entity<DatabaseSpace>().Property("Data").HasColumnName("data");
            modelBuilder.Entity<DatabaseSpace>().Property("IndexSize").HasColumnName("index_size");
            modelBuilder.Entity<DatabaseSpace>().Property("Unused").HasColumnName("unused");

            modelBuilder.Entity<DatabaseNameSP>().HasKey("DatabaseName");
            modelBuilder.Entity<DatabaseNameSP>().Property("DatabaseName").HasColumnName("DATABASE_NAME");
        }
    }
}
