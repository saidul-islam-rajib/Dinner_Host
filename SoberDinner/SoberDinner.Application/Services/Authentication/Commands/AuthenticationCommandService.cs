using ErrorOr;
using SoberDinner.Application.Common.Intefaces.Persistence;
using SoberDinner.Application.Common.Interfaces.Authentication;
using SoberDinner.Application.Services.Authentication.Common;
using SoberDinner.Domain.Common.Errors;
using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        
        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate user does exits
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2. Create uer (generate uqique ID) and persist to DB
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}

