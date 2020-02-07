namespace ToolBox.Common.Commands.IdentityService
{

    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}