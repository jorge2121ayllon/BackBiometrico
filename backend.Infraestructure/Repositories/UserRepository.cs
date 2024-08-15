using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(InversionContext context) : base(context) { }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.NombreUsuario == login.usuario && x.Erased == false);
        }
    }
}
