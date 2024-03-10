using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        public MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUqique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
