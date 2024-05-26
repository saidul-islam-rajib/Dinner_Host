using MediatR;
using SoberDinner.Application.Common.Interfaces.Persistence;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Application.Menus.Queries.MenuQueries
{
    
    public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        public GetAllMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var response = await _menuRepository.GetAllMenusAsync();
            return response;
        }
    }
}
