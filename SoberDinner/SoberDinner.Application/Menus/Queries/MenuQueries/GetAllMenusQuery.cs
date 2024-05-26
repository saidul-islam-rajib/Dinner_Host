using MediatR;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Application.Menus.Queries.MenuQueries
{
    public record GetAllMenusQuery : IRequest<IEnumerable<Menu>>;
}
