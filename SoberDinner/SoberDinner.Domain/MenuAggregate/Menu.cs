﻿

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
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections  => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            List<MenuSection>? sections,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name,
            string description,
            HostId hostId,
            List<MenuSection>? sections)
        {
            return new(
                    MenuId.CreateUqique(),
                    name,
                    description,
                    hostId,
                    sections ?? new(),
                    DateTime.UtcNow,
                    DateTime.UtcNow);
        }
    }
}
