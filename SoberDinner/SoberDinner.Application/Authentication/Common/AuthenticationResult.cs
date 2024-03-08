using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
