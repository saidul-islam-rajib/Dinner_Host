using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SoberDinner.API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new ObjectResult(new { error = "An error occurred while precessing your request" })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
            base.OnException(context);
        }
    }
}
