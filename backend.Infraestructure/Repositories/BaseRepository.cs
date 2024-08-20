using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InversionContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(InversionContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable().Where(x => x.Erased == false);
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(T entity)
        {
            entity.Erased = false;
            entity.Date = DateTime.Now;
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            entity.Date = DateTime.Now;
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            entity.Erased = true;
            _entities.Update(entity);
        }
    }
}
