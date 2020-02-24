using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Api.Services
{
        [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
        public interface ISqlMonitorService
        {
            //[AllowAnyStatusCode]
            //[Post("api/identity/sign-in")]
            //Task<object> SignIn([Body] SignInModel model);

            //[AllowAnyStatusCode]
            //[Post("api/identity/sign-up")]
            //Task<object> SignUp([Body] SignUpModel model);

            //[AllowAnyStatusCode]
            //[Post("api/tokens/refresh")]
            //Task<object> RefreshToken([Body] TokenModel model);
        }
}
