using System;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Helpers
{
    public static class Encryption
    {
        public static void EncryptPassword(this User user, IEncrypter encrypter)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ToolBoxException("Empty password", $"Password can not be empty.");
            }
            user.Salt = encrypter.GetSalt(user.Password);
            user.Password = encrypter.GetHash(user.Password, user.Salt);
        }

        public static bool ValidatePassword(this User user, string plainTextPassword, IEncrypter encrypter)
            => user.Password.Equals(encrypter.GetHash(plainTextPassword, user.Salt));

    }
}