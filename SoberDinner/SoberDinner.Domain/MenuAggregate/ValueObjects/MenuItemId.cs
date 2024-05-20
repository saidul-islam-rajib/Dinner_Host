using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }
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

#pragma warning disable CS8618
        private MenuItemId()
        {
        }
#pragma warning restore CS8618
    }
}
