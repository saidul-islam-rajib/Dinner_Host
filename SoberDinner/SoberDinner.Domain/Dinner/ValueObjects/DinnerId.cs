using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Dinner.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public Guid Value { get; }
        public AverageRating(Guid value)
        {
            Value = value;
        }

        public static AverageRating CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
