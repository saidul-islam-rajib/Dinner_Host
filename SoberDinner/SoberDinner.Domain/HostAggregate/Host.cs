using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.Common.ValueObjects;
using SoberDinner.Domain.DinnerAggregate.ValueObjects;
using SoberDinner.Domain.HostAggregate.ValueObjects;
using SoberDinner.Domain.MenuAggregate.ValueObjects;

namespace SoberDinner.Domain.HostAggregate
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        // TO DO UserId
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        public Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            List<MenuId>? menudIds,
            List<DinnerId>? dinnerIds,
            DateTime createdDateTime,
            DateTime updatedDateTime): base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            _menuIds = menudIds;
            _dinnerIds = dinnerIds;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(
            Guid hostId,
            string firstName,
            string lastName,
            string profileImage,
            List<MenuId>? menudIds,
            List<DinnerId>? dinnerIds,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new Host(
                HostId.Create(hostId),
                firstName,
                lastName,
                profileImage,
                menudIds,
                dinnerIds,
                createdDateTime,
                updatedDateTime);
        }
    }
}
