using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Api.Models;
using ToolBox.Common.Auth;

namespace ToolBox.Api.Services.Identity
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IIdentityService
    {
        [AllowAnyStatusCode]
      
        [Post("api/identity/sign-in")]
        Task<object> SignIn([Body] SignIn command);
    }
}
