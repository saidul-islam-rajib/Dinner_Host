

using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Menu.ValueObjects;

namespace SoberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> items)
        {
            MenuSection response = new MenuSection(
                MenuSectionId.CreateUqique(),
                name,
                description);
            return response;
        }
    }
}
