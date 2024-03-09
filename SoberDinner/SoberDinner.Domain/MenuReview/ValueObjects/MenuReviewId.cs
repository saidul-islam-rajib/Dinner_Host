using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; }
        public MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
