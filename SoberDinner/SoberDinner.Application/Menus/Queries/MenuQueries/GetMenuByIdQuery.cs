using MediatR;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Application.Menus.Queries.MenuQueries
{
    public record GetMenuByIdQuery(Guid MenuId) : IRequest<Menu>;
}
