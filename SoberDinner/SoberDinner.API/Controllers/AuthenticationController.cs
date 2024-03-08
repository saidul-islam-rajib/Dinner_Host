using Microsoft.AspNetCore.Mvc;
using SoberDinner.Application.Services.Authentication;
using SoberDinner.Contracts.Authentication;

namespace SoberDinner.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            OneOf.OneOf<AuthenticationResult, Application.Common.Errors.DuplicateEmailError> registerResult = _authenticationService.Register(
                            request.FirstName,
                            request.LastName,
                            request.Email,
                            request.Password);
            return registerResult.Match(
               authRresult => Ok(MapAuthResult(authRresult)),
                _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists"));
        }

        private IActionResult MapAuthResult(AuthenticationResult authResult)
        {
            var response = new AuthenticationResponse(
                            authResult.User.Id,
                            authResult.User.FirstName,
                            authResult.User.LastName,
                            authResult.User.Email,
                            authResult.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}
