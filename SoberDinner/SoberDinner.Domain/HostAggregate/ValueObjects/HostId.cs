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
            return new HostId(Guid.NewGuid());
        }
        public static HostId Create(Guid value)
        {
            return new HostId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
