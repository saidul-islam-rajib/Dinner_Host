using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Dinner.ValueObjects;
using SoberDinner.Domain.Host.ValueObjects;
using SoberDinner.Domain.Menu.Entities;
using SoberDinner.Domain.Menu.ValueObjects;
using SoberDinner.Domain.MenuReview.ValueObjects;

namespace SoberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<AverageRating> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections  => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<AverageRating> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name,
            string description,
            HostId hostId)
        {
            return new(
                    MenuId.CreateUqique(),
                    name,
                    description,
                    hostId,
                    DateTime.UtcNow,
                    DateTime.UtcNow);
        }
    }
}
