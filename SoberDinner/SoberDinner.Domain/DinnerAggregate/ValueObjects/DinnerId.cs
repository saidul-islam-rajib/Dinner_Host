

using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.MenuAggregate.ValueObjects;

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
            return new DinnerId(Guid.NewGuid());
        }
        public static DinnerId Create(Guid value)
        {
            return new DinnerId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
