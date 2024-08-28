using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.DTOs
{
    public  class JugadorListDto
    {
        public int Id { get; set; }
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
        public virtual CategoriaDto CategoriaNavigation { get; set; }
        public virtual ClubDto ClubNavigation { get; set; }
    }
}
