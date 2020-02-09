using System;

namespace ToolBox.Services.Identity.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        // public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }

        public User(string email, string name, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }

        // public void SetPassword(string password, IEncrypter encrypter)
        // {
        //     if (string.IsNullOrEmpty(password))
        //     {
        //         throw new CardException("Empty password", $"Password can not be empty.");
        //     }
        //     Salt = encrypter.GetSalt(password);
        //     Password = encrypter.GetHash(password, Salt);
        // }

        // public bool ValidatePassword(string password, IEncrypter encrypter)
        //     => Password.Equals(encrypter.GetHash(password, Salt));
    }
}