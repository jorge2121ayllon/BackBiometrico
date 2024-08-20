using backend.Core.CustomEntities;
using backend.Core.Entities;
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
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public CategoriaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            this._paginationOptions = options.Value;
        }

        public async Task Add(Categoria categoria)
        {
            categoria.Date = DateTime.Now;
            await _unitOfWork.CategoriaRepository.Add(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.CategoriaRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<Categoria> Get(int id)
        {
            return await _unitOfWork.CategoriaRepository.GetById(id);
        }

        public PagedList<Categoria> Gets(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var obj = _unitOfWork.CategoriaRepository.GetAll().ToList();

            if (filters.filter != null)
            {
                obj = obj.Where(x => x.Descripcion.ToLower().Contains(filters.filter.ToLower())).ToList();
            }

            var pageobj = PagedList<Categoria>.Create(obj, filters.PageNumber, filters.PageSize);

            return pageobj;
        }

        public bool Update(Categoria categoria)
        {
            _unitOfWork.CategoriaRepository.Update(categoria);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
