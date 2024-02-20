using SoberDinner.Application.Common.Interfaces.Authentication;

namespace SoberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResule Login(string email, string password)
        {
            
            return new AuthenticationResule(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                "token");
        }

        public AuthenticationResule Register(string firstName, string lastName, string email, string password)
        {
            //1. Check if user already exits
            //2. Create user if not exits(generate unique ID)
            //3. Create JWT Token

            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResule(
                userId,
                firstName,
                lastName,
                email,
                token);
        }
    }
}
