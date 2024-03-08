using ErrorOr;

namespace SoberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplciateEmail",
                description: "A conflicet error has occurred.");
        }
    }
}
