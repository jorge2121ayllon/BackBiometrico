using backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(UserLogin login);
    }
}
