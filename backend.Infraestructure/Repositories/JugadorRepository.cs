using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Repositories
{
    public class JugadorRepository : BaseRepository<Jugador>, IJugadorRepository
    {
        public JugadorRepository(InversionContext context) : base(context)
        {
        }
    }
}
