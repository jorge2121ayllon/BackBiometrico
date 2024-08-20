using backend.Core.CustomEntities;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IJugadorService
    {
        Task Add(Jugador jugador);
        PagedList<Jugador> Gets(PostQueryFilter filters);
        bool Update(Jugador jugador);
        Task<Jugador> Get(int id);
        Task<bool> Delete(int id);
    }
}
