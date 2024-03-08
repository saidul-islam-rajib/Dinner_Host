using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Services.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
