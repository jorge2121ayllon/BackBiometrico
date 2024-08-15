using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InversionContext _context;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(InversionContext context)
        {
            this._context = context;

        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

    
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
