using Microsoft.EntityFrameworkCore;
using SoberDinner.Domain.MenuAggregate;

namespace SoberDinner.Infrastructure.Persistence
{
    public class SoberDinnerDbContext : DbContext
    {
        public SoberDinnerDbContext(DbContextOptions<SoberDinnerDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(SoberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
