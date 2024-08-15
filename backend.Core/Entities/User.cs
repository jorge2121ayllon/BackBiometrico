using backend.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Entities
{
    public class User : BaseEntity
    {   
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Gmail { get; set; }
        public RoleType Rol { get; set; }
   
    }
}
