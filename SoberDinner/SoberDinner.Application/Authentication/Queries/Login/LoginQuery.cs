using ErrorOr;
using MediatR;
using SoberDinner.Application.Authentication.Common;

namespace SoberDinner.Application.Authentication.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
