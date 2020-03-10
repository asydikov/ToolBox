using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Helpers;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder, IServiceProvider services)
        {
            var user = new User(Guid.Parse("d2b248e2-07a5-4d2c-b4d4-d933a84ee5f6"), "test@test.com", "User");
            PasswordGenerate(services, user);
            modelBuilder.Entity<User>().HasData(user);
        }

        private static void PasswordGenerate(IServiceProvider services, User user)
        {
            using (var scope = services.CreateScope())
            {
                var scheduleService =
                   scope.ServiceProvider
                       .GetRequiredService<IPasswordHasher<User>>();

                user.SetPassword("pass", scheduleService);
            }
        }

    }
}