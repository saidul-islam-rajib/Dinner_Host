using ErrorOr;
using MediatR;
using SoberDinner.Application.Authentication.Common;

namespace SoberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password

    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
