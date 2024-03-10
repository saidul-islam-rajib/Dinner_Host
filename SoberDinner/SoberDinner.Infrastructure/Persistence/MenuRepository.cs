using SoberDinner.Application.Common.Interfaces.Persistence;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
