using backend.Core.Entities;
using System;
using System.Collections.Generic;

namespace backend.Infraestructure.Entities
{
    public partial class Jugador: BaseEntity
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string Foto { get; set; }
        public int Club { get; set; }
        public int Categoria { get; set; }

        public virtual Categoria CategoriaNavigation { get; set; }
        public virtual Club ClubNavigation { get; set; }
    }
}
