using System;

namespace ToolBox.Services.Identity.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public User()
        {

        }

        public User(Guid id, string email, string name) : base(id)
        {
            Email = email;
            Name = name;
        }
    }
}