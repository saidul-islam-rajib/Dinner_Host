using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.MenuAggregate.ValueObjects
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
    }
}
