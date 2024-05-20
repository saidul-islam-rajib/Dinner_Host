using SoberDinner.Domain.Common.Models;
using SoberDinner.Domain.MenuAggregate.ValueObjects;

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
        public static MenuItemId Create(Guid value)
        {
            return new MenuItemId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
