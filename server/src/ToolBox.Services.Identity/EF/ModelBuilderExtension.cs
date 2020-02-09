using System;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User("test@test.com", "Nick", "1"),
            new User("test@test.com", "John", "1"),
            new User("test@test.com", "Roe", "1")
            );
        }

    }
}