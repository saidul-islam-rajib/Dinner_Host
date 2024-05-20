using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; private set; }
        public MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUqique()
        {
            return new MenuId(Guid.NewGuid());
        }
        public static MenuId Create(Guid value)
        {
            return new MenuId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private MenuId()
        {
        }
#pragma warning restore CS8618
    }
}
