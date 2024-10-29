using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IEmpleadoRepository //: IRepository<Empleado>
    {
        Task<bool> DeleteFingerprint(string nombre);
    }
}
