using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetByLogin(string login);
        string GenerateToken(User user);
    }
}
