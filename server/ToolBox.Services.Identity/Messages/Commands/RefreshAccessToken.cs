using Newtonsoft.Json;
using System;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
{
    [MessageNamespace("identity")]
    public class RefreshAccessToken : ICommand
    {
        public Guid Id { get; }
        public string Token { get; set; }

        public RefreshAccessToken()
        {

        }
        [JsonConstructor]
        public RefreshAccessToken(Guid? id, string token)
        {
            Id = id ?? Guid.NewGuid();
            Token = token;
        }
    }
}