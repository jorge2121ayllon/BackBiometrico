using backend.Core.CustomEntities;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Services
{
    public  class ClubService: IClubService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public ClubService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options) 
        {
            _unitOfWork = unitOfWork;
            this._paginationOptions = options.Value;
        }

        public async Task Add(Club club)
        {
            club.Date = DateTime.Now;
            await _unitOfWork.ClubRepository.Add(club);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ClubRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<Club> Get(int id)
        {
            return await _unitOfWork.ClubRepository.GetById(id);
        }

        public PagedList<Club> Gets(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var obj = _unitOfWork.ClubRepository.GetAll().ToList();

            if (filters.filter != null)
            {
                obj = obj.Where(x => x.Descripcion.ToLower().Contains(filters.filter.ToLower())).ToList();
            }

            var pageobj = PagedList<Club>.Create(obj, filters.PageNumber, filters.PageSize);

            return pageobj;
        }

        public bool Update(Club club)
        {
            _unitOfWork.ClubRepository.Update(club);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
