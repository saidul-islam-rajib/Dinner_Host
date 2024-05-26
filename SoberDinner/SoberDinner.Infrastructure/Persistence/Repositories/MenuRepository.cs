using Microsoft.EntityFrameworkCore;
using SoberDinner.Application.Common.Interfaces.Persistence;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly SoberDinnerDbContext _dbContext;

        public MenuRepository(SoberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Menu menu)
        {
            _dbContext.Add(menu);

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            var response = await _dbContext.Menus.ToListAsync();
            return response;
        }
    }
}
