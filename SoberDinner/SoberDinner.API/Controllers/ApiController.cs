using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SoberDinner.API.Http;

namespace SoberDinner.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.All(error => error.Type == ErrorType.Validation))
            {
                var modelStateDictionary = new ModelStateDictionary();
                foreach (var error in errors)
                {
                    modelStateDictionary.AddModelError(
                        error.Code,
                        error.Description);
                }
                return ValidationProblem(modelStateDictionary);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
