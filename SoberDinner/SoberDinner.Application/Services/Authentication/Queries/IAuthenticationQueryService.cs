using ErrorOr;
using SoberDinner.Application.Services.Authentication.Common;

namespace SoberDinner.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
