using Newtonsoft.Json;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
{
    public class RefreshAccessToken : ICommand
    {
        public string Token { get; set; }

        public RefreshAccessToken()
        {

        }
        [JsonConstructor]
        public RefreshAccessToken(string token)
        {
            Token = token;
        }
    }
}