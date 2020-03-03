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
    [Migration("20200302204206_Added_new_SqlQueries_Updated")]
    partial class Added_new_SqlQueries_Updated
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6a8bf00-83e9-4541-ba85-a616c8166122"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(6747),
                            IsActive = true,
                            Name = "SqlMonitor",
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(6771)
                        },
                        new
                        {
                            Id = new Guid("b1843653-ccf3-457f-bcb3-6040bf2f0fbe"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8875),
                            IsActive = true,
                            Name = "SqlMonitor",
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8882)
                        },
                        new
                        {
                            Id = new Guid("d961c3a4-c027-4c28-8afc-449d55472806"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8962),
                            IsActive = true,
                            Name = "modeldb",
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8963)
                        },
                        new
                        {
                            Id = new Guid("9915d74b-a3ba-4e55-9446-edd2c493d134"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8987),
                            IsActive = true,
                            Name = "msdb",
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(8988)
                        },
                        new
                        {
                            Id = new Guid("b63d70da-5ae2-4b9a-bc31-5edb2cc7b3ab"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(9009),
                            IsActive = true,
                            Name = "tempdb",
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 814, DateTimeKind.Utc).AddTicks(9010)
                        });
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
                            Id = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Utc).AddTicks(4004),
                            Interval = 4,
                            IsActive = true,
                            IsForServer = true,
                            LastInvokedDate = new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Local).AddTicks(4672),
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 816, DateTimeKind.Utc).AddTicks(4010)
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

                    b.HasData(
                        new
                        {
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            ServerId = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8")
                        });
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
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            SqlQueryId = new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3")
                        },
                        new
                        {
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            SqlQueryId = new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794")
                        },
                        new
                        {
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            SqlQueryId = new Guid("1c1ea729-9210-43bb-85f4-854005bf107a")
                        },
                        new
                        {
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            SqlQueryId = new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e")
                        },
                        new
                        {
                            ScheduleId = new Guid("ba8059a7-5a93-4a4a-a063-5fd57355812a"),
                            SqlQueryId = new Guid("f590683f-c347-4bf5-ab73-c8911c7469db")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("eadc77bc-01f5-4910-86a1-09787ca5daf8"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 812, DateTimeKind.Utc).AddTicks(2138),
                            Host = "localhost",
                            IsActive = true,
                            Login = "sa",
                            Name = "Sql monitor server",
                            Password = "Pass_w0rd12",
                            Port = 1465,
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 812, DateTimeKind.Utc).AddTicks(3814),
                            UserId = new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6")
                        });
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
                            Id = new Guid("e30573c0-c2fb-4a12-b79b-8891f30f41e3"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7677),
                            Description = "List of Database names in a server",
                            IsActive = true,
                            IsStoredProcedure = true,
                            Name = 1,
                            Query = "EXEC sp_databases",
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7683)
                        },
                        new
                        {
                            Id = new Guid("5ce58f94-3d76-4218-9968-a08eedbe4794"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7739),
                            Description = "Needs to be executed with keyword use [DATABASE_NAME]. Database space information",
                            IsActive = true,
                            IsStoredProcedure = true,
                            Name = 3,
                            Query = "EXEC sp_spaceused @oneresultset = 1",
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7740)
                        },
                        new
                        {
                            Id = new Guid("1c1ea729-9210-43bb-85f4-854005bf107a"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7743),
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
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7745)
                        },
                        new
                        {
                            Id = new Guid("27604b4f-19e4-4ff6-a8de-ba42ff5aab5e"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7747),
                            Description = "Finding users that are connected to the server",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 4,
                            Query = @"SELECT login_name ,COUNT(session_id) AS session_count   
                          FROM sys.dm_exec_sessions
                          GROUP BY login_name; ",
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7748)
                        },
                        new
                        {
                            Id = new Guid("f590683f-c347-4bf5-ab73-c8911c7469db"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7754),
                            Description = "Memory usage",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 6,
                            Query = @"SELECT object_name, counter_name, cntr_value
                            FROM sys.dm_os_performance_counters
                            WHERE [object_name] LIKE '%Buffer Manager%'
                            AND [counter_name] in ('Page life expectancy','Free list stalls/sec',
                            'Page reads/sec')",
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7755)
                        },
                        new
                        {
                            Id = new Guid("d6e7476d-3bce-4fa5-afcd-88965a976096"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7751),
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
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(7752)
                        },
                        new
                        {
                            Id = new Guid("d1f1ff22-2f9f-409d-b229-a967e67259a4"),
                            CreatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(5586),
                            Description = "The name of a server",
                            IsActive = true,
                            IsStoredProcedure = false,
                            Name = 0,
                            Query = "SELECT SERVERPROPERTY('Servername') as ServerName",
                            UpdatedDate = new DateTime(2020, 3, 2, 20, 42, 5, 815, DateTimeKind.Utc).AddTicks(5614)
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