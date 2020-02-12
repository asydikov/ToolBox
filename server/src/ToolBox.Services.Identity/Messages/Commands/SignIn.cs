using Newtonsoft.Json;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
{
    public class SignIn : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SignIn()
        {

        }
        [JsonConstructor]
        public SignIn(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}