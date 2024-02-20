using SoberDinner.Domain.Entities;
namespace SoberDinner.Application.Common.Intefaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}

