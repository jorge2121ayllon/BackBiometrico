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
    public class JugadorService : IJugadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private IEnumerable<Jugador> obj;

        public JugadorService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            this._paginationOptions = options.Value;
        }
        public async Task Add(Jugador jugador)
        {
            jugador.Date = DateTime.Now;
            await _unitOfWork.JugadorRepository.Add(jugador);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.JugadorRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<Jugador> Get(int id)
        {
            return await _unitOfWork.JugadorRepository.GetById(id);
        }

        public PagedList<Jugador> Gets(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;



           
            if (filters.filter != null)
            {
               var  obj = _unitOfWork.JugadorRepository.GetAll().
                       Where(   x => ( x.Nombre.ToLower().Trim() +" "+ x.ApellidoPaterno.ToLower().Trim() +" "+ x.ApellidoMaterno.ToLower().Trim() ).Contains(filters.filter.ToLower().Trim())
                       || x.Ci.ToLower().Trim() == filters.filter.ToLower().Trim()
                       ).ToList();
            }
            else
            {
                var obj = _unitOfWork.JugadorRepository.GetAll().ToList();

                
            }

            var pageobj = PagedList<Jugador>.Create(obj, filters.PageNumber, filters.PageSize);


            return pageobj;
        }

        public bool Update(Jugador jugador)
        {
            _unitOfWork.JugadorRepository.Update(jugador);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
