using MediatR;
using SoberDinner.Application.Common.Interfaces.Persistence;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Application.Menus.Queries.MenuQueries
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, Menu>
    {
        private readonly IMenuRepository _menuRepository;

        public GetMenuByIdQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _menuRepository.GetMenuByIdAsync(request.MenuId);
            return response;
        }
    }
}
