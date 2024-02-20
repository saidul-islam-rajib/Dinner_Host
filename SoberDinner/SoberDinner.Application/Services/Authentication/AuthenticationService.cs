using SoberDinner.Application.Common.Intefaces.Persistence;
using SoberDinner.Application.Common.Interfaces.Authentication;
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

        public AuthenticationResule Login(string email, string password)
        {
            // 1. Validate the user exits
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist.");
            }

            // 2. Validate the password is correct
            if(user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResule(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                "token");
        }

        public AuthenticationResule Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate user does exits
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email address already exits!");
            }

            // 2. Create uer (generate uqique ID) and persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

            return new AuthenticationResule(
                user.Id,
                firstName,
                lastName,
                email,
                token);
        }
    }
}
