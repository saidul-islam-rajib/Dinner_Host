

using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; }
        public DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
