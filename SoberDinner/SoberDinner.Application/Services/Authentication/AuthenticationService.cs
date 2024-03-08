using ErrorOr;
using FluentResults;
using SoberDinner.Application.Common.Errors;
using SoberDinner.Application.Common.Intefaces.Persistence;
using SoberDinner.Application.Common.Interfaces.Authentication;
using SoberDinner.Domain.Common.Errors;
using SoberDinner.Domain.Entities;

namespace SoberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // 1. Validate the user exits
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if(user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate user does exits
            if(_userRepository.GetUserByEmail(email) is not null)
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

