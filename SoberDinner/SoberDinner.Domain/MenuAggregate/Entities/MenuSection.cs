

using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Menu.ValueObjects;

namespace SoberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> items)
        {
            MenuSection response = new MenuSection(
                MenuSectionId.CreateUqique(),
                name,
                description,
                items);
            return response;
        }

#pragma warning disable CS8618
        private MenuSection()
        {
        }
#pragma warning restore CS8618
    }
}
