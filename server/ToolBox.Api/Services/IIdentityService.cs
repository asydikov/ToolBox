using RestEase;
using System.Threading.Tasks;
using ToolBox.Api.Domain.Models.Identity;

namespace ToolBox.Api.Services.Identity
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IIdentityService
    {
        [AllowAnyStatusCode]
        [Post("api/identity/sign-in")]
        Task<object> SignIn([Body] SignInModel model);

        [AllowAnyStatusCode]
        [Post("api/identity/sign-up")]
        Task<object> SignUp([Body] SignUpModel model);

        [AllowAnyStatusCode]
        [Post("api/tokens/refresh")]
        Task<object> RefreshToken([Body] TokenModel model);
    }
}
