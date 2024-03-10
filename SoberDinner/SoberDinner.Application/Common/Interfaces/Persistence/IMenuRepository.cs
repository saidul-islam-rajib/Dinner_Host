using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
