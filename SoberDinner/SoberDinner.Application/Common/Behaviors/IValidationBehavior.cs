using ErrorOr;
using MediatR;

namespace SoberDinner.Application.Common.Behaviors
{
    public interface IValidationBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
    }
}