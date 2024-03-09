using ErrorOr;
using MediatR;
using SoberDinner.Application.Authentication.Common;
using SoberDinner.Application.Common.Intefaces.Persistence;
using SoberDinner.Application.Common.Interfaces.Authentication;
using SoberDinner.Domain.Common.Errors;
using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate the user exits
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
