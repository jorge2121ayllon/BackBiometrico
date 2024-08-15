using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }


        void SaveChanges();
        Task SaveChangesAsync();

    }
}
