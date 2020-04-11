using System;
using Microsoft.AspNetCore.Identity;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Helpers
{
    public static class RefreshTokenExtention
    {
        public static void SetToken(this RefreshToken refreshToken, User user, IPasswordHasher<User> passwordHasher)
        {
            refreshToken.UserId = user.Id;
            refreshToken.Token = CreateToken(user, passwordHasher);
        }

        private static string CreateToken(User user, IPasswordHasher<User> passwordHasher)
            => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N"))
                .Replace("=", string.Empty)
                .Replace("+", string.Empty)
                .Replace("/", string.Empty);
    }
}