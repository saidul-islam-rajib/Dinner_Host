using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Menu.ValueObjects;

namespace SoberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(
            string name,
            string description)
        {
            return new(
                MenuItemId.CreateUqique(),
                name,
                description);
        }
    }
}
