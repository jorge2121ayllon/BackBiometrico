using backend.Core.Entities;
using System;
using System.Collections.Generic;

namespace backend.Infraestructure.Entities
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Huella { get; set; }
    }
}
