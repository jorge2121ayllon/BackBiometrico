using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Gmail { get; set; }
        public string Rol { get; set; }
    }
}
