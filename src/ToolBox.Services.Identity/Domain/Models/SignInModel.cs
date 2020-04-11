using Newtonsoft.Json;
using System;


namespace ToolBox.Services.Identity.Domain.Models
{
    public class SignInModel
    {
        public Guid Id { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignInModel()
        {

        }
        public SignInModel(Guid? id, string email, string password)
        {
            Id = id ?? Guid.NewGuid();
            Email = email;
            Password = password;
        }
    }
}