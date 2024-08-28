using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Interfaces
{
    public interface IJugadorRepository:IRepository<Jugador>
    {
        IEnumerable<Jugador> GetAllNavigation();
    }
}
