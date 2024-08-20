using backend.Core.CustomEntities;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Interfaces
{
    public interface IClubService
    {
        Task Add(Club club);
        PagedList<Club> Gets(PostQueryFilter filters);
        bool Update(Club club);
        Task<Club> Get(int id);
        Task<bool> Delete(int id);
    }
}
