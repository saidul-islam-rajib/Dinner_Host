namespace SoberDinner.Application.Services.Authentication
{
    public record AuthenticationResule
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
