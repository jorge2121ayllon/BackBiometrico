using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.DTOs
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Huella { get; set; }
    }
}
