using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
