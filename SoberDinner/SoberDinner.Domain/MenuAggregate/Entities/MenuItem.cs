using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Menu.ValueObjects;

namespace SoberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        private MenuItem(
            MenuItemId menuItemId,
            string name,
            string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(
            string name,
            string description)
        {
            MenuItem response = new MenuItem(
                MenuItemId.CreateUqique(),
                name,
                description);
            return response;
        }

#pragma warning disable CS8618
        private MenuItem()
        {
        }
#pragma warning restore CS8618
    }
}
