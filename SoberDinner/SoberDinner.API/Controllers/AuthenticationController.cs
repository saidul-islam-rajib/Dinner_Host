using FluentResults;
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
            Result<AuthenticationResult> registerResult = _authenticationService.Register(
                            request.FirstName,
                            request.LastName,
                            request.Email,
                            request.Password);
            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }

            var firstError = registerResult.Errors[0]; // taking first error
            if(firstError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already exists.");
            }

            return Problem();
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
