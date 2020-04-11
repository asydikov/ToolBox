using System;
using Microsoft.AspNetCore.Identity;

namespace ToolBox.Services.Identity.Entities
{
    public class RefreshToken : EntityBase
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public User User { get; set; }

        public override void SetUpdatedDate()
        {
            base.SetUpdatedDate();
        }
    }
}