using Microsoft.EntityFrameworkCore;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.EF
{
    public class SqlMonitorDbContext : DbContext
    {
        public SqlMonitorDbContext(DbContextOptions<SqlMonitorDbContext> options)
              : base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<SqlQuery> SQLQueries { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<DatabaseBackupMetrics> DatabaseBackupMetrics { get; set; }
        public DbSet<DatabaseSpaceMetrics> DatabaseSpaceMetrics { get; set; }
        public DbSet<MemoryUsageMetrics> MemoryUsageMetrics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseBackupMetrics>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<DatabaseSpaceMetrics>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<MemoryUsageMetrics>().Property(x => x.Id).IsRequired();


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


            modelBuilder.Entity<SqlQuery>().Property(x => x.Query).IsRequired();
            modelBuilder.Entity<SqlQuery>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<SqlQuery>().Property(x => x.IsStoredProcedure).IsRequired();
            modelBuilder.Entity<Schedule>().Property(x => x.Interval).IsRequired();

            modelBuilder.Entity<ScheduleServer>()
        .HasKey(bc => new { bc.ScheduleId, bc.ServerId });

            modelBuilder.Entity<ScheduleServer>()
                .HasOne(bc => bc.Schedule)
                .WithMany(b => b.ScheduleServers)
                .HasForeignKey(bc => bc.ScheduleId);

            modelBuilder.Entity<ScheduleServer>()
                .HasOne(bc => bc.Server)
                .WithMany(c => c.ScheduleServers)
                .HasForeignKey(bc => bc.ServerId);


            modelBuilder.Entity<ScheduleSqlQuery>()
       .HasKey(bc => new { bc.ScheduleId, bc.SqlQueryId });

            modelBuilder.Entity<ScheduleSqlQuery>()
                .HasOne(bc => bc.Schedule)
                .WithMany(b => b.ScheduleSqlQueries)
                .HasForeignKey(bc => bc.ScheduleId);

            modelBuilder.Entity<ScheduleSqlQuery>()
              .HasOne(bc => bc.SqlQuery)
              .WithMany(c => c.ScheduleSqlQueries)
              .HasForeignKey(bc => bc.SqlQueryId);



            modelBuilder.Seed();
        }

    }
}