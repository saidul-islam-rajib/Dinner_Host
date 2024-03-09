using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }
        public MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
