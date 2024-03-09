using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Host.ValueObjects
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
    }
}
