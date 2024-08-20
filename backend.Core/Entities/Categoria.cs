using backend.Core.Entities;
using System;
using System.Collections.Generic;

namespace backend.Infraestructure.Entities
{
    public partial class Categoria: BaseEntity
    {
        public Categoria()
        {
            Jugador = new HashSet<Jugador>();
        }

        public string Descripcion { get; set; }

        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
