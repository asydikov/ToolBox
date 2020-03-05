﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToolBox.Services.SQLMonitor.EF;

namespace ToolBox.Services.SQLMonitor.Migrations
{
    [DbContext(typeof(SqlMonitorDbContext))]
    [Migration("20200304121217_Database_Metrics_Update")]
    partial class Database_Metrics_Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.Database", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Databases");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.DatabaseBackupMetrics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DatabaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Differential")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Full")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RecoveryModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Transaction")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DatabaseId");

                    b.ToTable("DatabaseBackupMetrics");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.DatabaseSpaceMetrics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DatabaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Space")
                        .HasColumnType("float");

                    b.Property<double>("UnallocatedSpace")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DatabaseId");

                    b.ToTable("DatabaseSpaceMetrics");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.MemoryUsageMetrics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PageLifetime")
                        .HasColumnType("int");

                    b.Property<int>("PageReadsCount")
                        .HasColumnType("int");

                    b.Property<int>("RequestsCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("MemoryUsageMetrics");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Interval")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForServer")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastInvokedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Utc).AddTicks(5386),
                            Interval = 4,
                            IsActive = true,
                            IsForServer = true,
                            LastInvokedDate = new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Local).AddTicks(6059),
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 272, DateTimeKind.Utc).AddTicks(5425)
                        });
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.ScheduleServer", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ScheduleId", "ServerId");

                    b.HasIndex("ServerId");

                    b.ToTable("ScheduleServer");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.ScheduleSqlQuery", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SqlQueryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ScheduleId", "SqlQueryId");

                    b.HasIndex("SqlQueryId");

                    b.ToTable("ScheduleSqlQuery");

                    b.HasData(
                        new
                        {
                            ScheduleId = new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"),
                            SqlQueryId = new Guid("46d73ff0-4214-4528-b24d-d56b598e6146")
                        },
                        new
                        {
                            ScheduleId = new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"),
                            SqlQueryId = new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4")
                        },
                        new
                        {
                            ScheduleId = new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"),
                            SqlQueryId = new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c")
                        },
                        new
                        {
                            ScheduleId = new Guid("690e2ccf-ad32-4a1f-8ce8-e271d05ebc23"),
                            SqlQueryId = new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3")
                        });
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.SqlQuery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStoredProcedure")
                        .HasColumnType("bit");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SQLQueries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46d73ff0-4214-4528-b24d-d56b598e6146"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6444),
                            Description = "Database space information",
                            IsActive = true,
                            IsStoredProcedure = true,
                            Name = 3,
                            Query = "sp_spaceused",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6465)
                        },
                        new
                        {
                            Id = new Guid("97cbefbc-a2da-4fe6-9dfe-c8c2e61318b4"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6526),
                            Description = "Databases backup status",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 2,
                            Query = @"SELECT d.name AS 'DATABASE_Name',
                          MAX(CASE WHEN bu.TYPE = 'D' THEN bu.LastBackupDate END) AS 'Full DB Backup Status',
                          MAX(CASE WHEN bu.TYPE = 'I' THEN bu.LastBackupDate END) AS 'Differential DB Backup Status',
                          MAX(CASE WHEN bu.TYPE = 'L' THEN bu.LastBackupDate END) AS 'Transaction DB Backup Status',
                          CASE d.recovery_model WHEN 1 THEN 'Full' WHEN 2 THEN 'Bulk Logged' WHEN 3 THEN 'Simple' END RecoveryModel
                          FROM MASTER.sys.databases d
                          LEFT OUTER JOIN (SELECT database_name, TYPE, MAX(backup_start_date) AS LastBackupDate
                          FROM msdb.dbo.backupset
                          GROUP BY database_name, TYPE) AS bu ON d.name = bu.database_name
                          GROUP BY d.Name, d.recovery_model",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6528)
                        },
                        new
                        {
                            Id = new Guid("0b41aa8c-0b16-4722-a814-5aa45bd2cf3c"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6530),
                            Description = "Finding users that are connected to the server",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 4,
                            Query = @"SELECT login_name ,COUNT(session_id) AS session_count   
                          FROM sys.dm_exec_sessions
                          GROUP BY login_name; ",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6531)
                        },
                        new
                        {
                            Id = new Guid("cbe4545a-9641-4aa6-aff5-5a4475bdb2a3"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6556),
                            Description = "Memory usage",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 6,
                            Query = @"SELECT object_name, counter_name, cntr_value
                            FROM sys.dm_os_performance_counters
                            WHERE [object_name] LIKE '%Buffer Manager%'
                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                            'Page reads/sec')",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6557)
                        },
                        new
                        {
                            Id = new Guid("1cc7230a-3bb3-4136-836e-3e0688faab71"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6533),
                            Description = "List of Database names in a server",
                            IsActive = true,
                            IsStoredProcedure = true,
                            Name = 1,
                            Query = "sp_databases",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6534)
                        },
                        new
                        {
                            Id = new Guid("ba443025-cf1d-4f2a-b790-f5f2908ee309"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6550),
                            Description = "The most CPU consumed 20 queries",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 5,
                            Query = @"SELECT TOP 20 query_stats.query_hash AS 'Query Hash',   
	                        	SUM(query_stats.total_worker_time) / SUM(query_stats.execution_count) AS 'Avg CPU Time',  
	                        	MIN(query_stats.statement_text) AS 'Statement Text'  
	                        FROM   
	                        	(SELECT QS.*,   
	                        	SUBSTRING(ST.text, (QS.statement_start_offset/2) + 1,  
	                        	((CASE statement_end_offset   
	                        		WHEN -1 THEN DATALENGTH(ST.text)  
	                        		ELSE QS.statement_end_offset END   
	                        			- QS.statement_start_offset)/2) + 1) AS statement_text  
	                        	 FROM sys.dm_exec_query_stats AS QS  
	                        	 CROSS APPLY sys.dm_exec_sql_text(QS.sql_handle) as ST) as query_stats  
	                        GROUP BY query_stats.query_hash  
	                        ORDER BY 2 DESC;  
                        ",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(6551)
                        },
                        new
                        {
                            Id = new Guid("8d3e4ba6-99bc-476b-bd4b-181ae59b32be"),
                            CreatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(2073),
                            Description = "The name of a server",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 0,
                            Query = "SELECT SERVERPROPERTY('Servername') as ServerName",
                            UpdatedDate = new DateTime(2020, 3, 4, 12, 12, 17, 270, DateTimeKind.Utc).AddTicks(3857)
                        });
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.Database", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Server", "Server")
                        .WithMany("Databases")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.DatabaseBackupMetrics", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Database", "Database")
                        .WithMany()
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.DatabaseSpaceMetrics", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Database", "Database")
                        .WithMany()
                        .HasForeignKey("DatabaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.MemoryUsageMetrics", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.ScheduleServer", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Schedule", "Schedule")
                        .WithMany("ScheduleServers")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Server", "Server")
                        .WithMany("ScheduleServers")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToolBox.Services.SQLMonitor.Entities.ScheduleSqlQuery", b =>
                {
                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.Schedule", "Schedule")
                        .WithMany("ScheduleSqlQueries")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToolBox.Services.SQLMonitor.Entities.SqlQuery", "SqlQuery")
                        .WithMany("ScheduleSqlQueries")
                        .HasForeignKey("SqlQueryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
