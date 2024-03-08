using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SoberDinner.Application.Common.Errors;
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
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                            request.FirstName,
                            request.LastName,
                            request.Email,
                            request.Password);

            return authResult.MatchFirst(
                authResult => Ok(MapAuthResult(authResult)),
                firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
            );
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
            ErrorOr<AuthenticationResult> logingResult = _authenticationService.Login(
                request.Email,
                request.Password);

            return logingResult.MatchFirst(
                authResult => Ok(MapAuthResult(authResult)),
                firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
            );
        }
    }
}
