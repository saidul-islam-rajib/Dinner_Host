using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SoberDinner.Application.Services.Authentication;
using SoberDinner.Contracts.Authentication;
using SoberDinner.Domain.Common.Errors;

namespace SoberDinner.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
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

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized,
                               title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
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
    }
}
