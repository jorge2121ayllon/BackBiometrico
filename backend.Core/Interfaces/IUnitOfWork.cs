using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IClubRepository ClubRepository { get; }
        IJugadorRepository JugadorRepository { get; }


        void SaveChanges();
        Task SaveChangesAsync();

    }
}
