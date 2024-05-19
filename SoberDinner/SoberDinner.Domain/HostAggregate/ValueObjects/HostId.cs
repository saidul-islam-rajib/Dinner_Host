using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }
        public HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static HostId Create(string value)
        {
            return new (Guid.NewGuid());
        }


    }
}
