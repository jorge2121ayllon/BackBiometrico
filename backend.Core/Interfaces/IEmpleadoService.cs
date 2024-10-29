using backend.Core.CustomEntities;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IEmpleadoService
    {
        Task Add(Empleado empleado);
        PagedList<Empleado> Gets(PostQueryFilter filters);
        bool Update(Empleado empleado);
        Task<Empleado> Get(int id);
        Task<bool> Delete(int id);
        Task<bool> DeleteFingerPrint(string nombre);
    }
}
