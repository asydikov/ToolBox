using Microsoft.AspNetCore.Identity;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Entities;

namespace ToolBox.Services.Identity.Helpers
{
    public static class UserExtension
    {
        public static void SetPassword(this User user, string newPassword, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ToolBoxException(Codes.InvalidPassword,
                    "Password can not be empty.");
            }
            user.Password = passwordHasher.HashPassword(user, newPassword);
        }

        public static bool ValidatePassword(this User user, string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(user, user.Password, password) != PasswordVerificationResult.Failed;
    }
}