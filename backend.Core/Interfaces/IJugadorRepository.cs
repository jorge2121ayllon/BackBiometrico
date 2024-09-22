using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IJugadorRepository:IRepository<Jugador>
    {
        IEnumerable<Jugador> GetAllNavigation();
        Task<Jugador> GetByIdAllNavigation(int id);
        
        IEnumerable<Jugador> GetAllNavigationFromClub(int Club, int Categoria);
    }
}
