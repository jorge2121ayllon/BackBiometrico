using backend.Core.Interfaces;
using backend.Infraestructure.Data;
using backend.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Repositories
{
    public class ClubRepository : BaseRepository<Club>, IClubRepository
    {
        public ClubRepository(InversionContext context) : base(context)
        {
        }
    }
}
