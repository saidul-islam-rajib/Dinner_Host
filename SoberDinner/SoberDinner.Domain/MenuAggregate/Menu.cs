

using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Common.ValueObjects;
using SoberDinner.Domain.DinnerAggregate.ValueObjects;
using SoberDinner.Domain.HostAggregate.ValueObjects;
using SoberDinner.Domain.MenuAggregate.Entities;
using SoberDinner.Domain.MenuAggregate.ValueObjects;
using SoberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace SoberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections  => _sections.AsReadOnly();
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }


        private Menu(
            MenuId menuId,
            HostId hostId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections)
            : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            _sections = sections;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections)
        {
            Menu response = new Menu(
                MenuId.CreateUqique(),
                hostId,
                name,
                description,
                AverageRating.CreateNew(),
                sections);

            return response;
        }

#pragma warning disable CS8618
        private Menu()
        {
        }
#pragma warning restore CS8618
    }
}
