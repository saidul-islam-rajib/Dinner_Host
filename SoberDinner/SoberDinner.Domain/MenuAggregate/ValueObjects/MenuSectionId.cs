using SoberDinner.Domain.Common.Models;

namespace SoberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        public MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUqique()
        {
            return new(Guid.NewGuid());
        }
        public static MenuSectionId Create(Guid value)
        {
            return new MenuSectionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private MenuSectionId()
        {
        }
#pragma warning restore CS8618
    }
}
