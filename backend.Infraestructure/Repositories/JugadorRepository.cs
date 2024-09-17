using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using backend.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infraestructure.Repositories
{
    public class JugadorRepository : BaseRepository<Jugador>, IJugadorRepository
    {
        public JugadorRepository(InversionContext context) : base(context)
        {
        }

        public IEnumerable<Jugador> GetAllNavigation()
        {
            return _entities.Include(obj => obj.CategoriaNavigation).Include(obj=>obj.ClubNavigation).AsEnumerable().Where(x => x.Erased == false);
        }

        public Task<Jugador> GetByIdAllNavigation(int id)
        {
            return  _entities.Include(obj => obj.CategoriaNavigation).Include(obj => obj.ClubNavigation).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
