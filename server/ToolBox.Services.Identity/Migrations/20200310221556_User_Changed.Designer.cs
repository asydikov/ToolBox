﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToolBox.Services.Identity.EF;

namespace ToolBox.Services.Identity.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20200310221556_User_Changed")]
    partial class User_Changed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToolBox.Services.Identity.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ToolBox.Services.Identity.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RefreshTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"),
                            CreatedDate = new DateTime(2020, 3, 10, 22, 15, 56, 21, DateTimeKind.Utc).AddTicks(1005),
                            Email = "test@test.com",
                            IsActive = true,
                            Name = "User",
                            Password = "AQAAAAEAACcQAAAAEH3HQ6kVA6Rq/NYCNTvVhomoMb4enitBbcoDmaFNzgiM2TRG5wByoDqXEV56vqSVEQ==",
                            RefreshTokenId = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdatedDate = new DateTime(2020, 3, 10, 22, 15, 56, 21, DateTimeKind.Utc).AddTicks(2926)
                        });
                });

            modelBuilder.Entity("ToolBox.Services.Identity.Entities.RefreshToken", b =>
                {
                    b.HasOne("ToolBox.Services.Identity.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("ToolBox.Services.Identity.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
