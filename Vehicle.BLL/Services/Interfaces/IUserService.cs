using System.Collections.Generic;
using Vehicle.BLL.Models;

namespace Vehicle.BLL.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        User Add(User user);

        User Update(User user);

        void DeleteById(int id);

        void Delete(User user);
    }
}
