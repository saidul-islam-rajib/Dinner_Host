using System.Net;

namespace SoberDinner.Application.Common.Errors
{
    public interface IErrors
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
