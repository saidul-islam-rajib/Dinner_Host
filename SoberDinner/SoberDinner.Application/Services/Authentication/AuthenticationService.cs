namespace SoberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
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
            return new AuthenticationResule(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                "token");
        }
    }
}
