using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(InversionContext context) : base(context)
        {
        }
    }
}
