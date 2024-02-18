namespace SoberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResule Login(string email, string password);
        AuthenticationResule Register(string firstName, string lastName, string email, string password);
    }
}
