using backend.Core.CustomEntities;
using backend.Core.Entities;
using backend.Core.QueryFilters;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(User user);
        PagedList<User> GetUsers(PostQueryFilter filters);
        bool UpdateUser(User user);
        Task<User> GetUser(int id);
        string GetPassword(int id);
        Task<bool> DeleteUser(int id);
    }
}
