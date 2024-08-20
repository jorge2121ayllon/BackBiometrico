using backend.Core.CustomEntities;
using backend.Core.Entities;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task Add(Categoria categoria);
        PagedList<Categoria> Gets(PostQueryFilter filters);
        bool Update(Categoria categoria);
        Task<Categoria> Get(int id);
        Task<bool> Delete(int id);
    }
}
