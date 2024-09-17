using backend.Core.CustomEntities;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
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
            return await _unitOfWork.JugadorRepository.GetByIdAllNavigation(id);
        }

        public PagedList<Jugador> Gets(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;



            var obj = _unitOfWork.JugadorRepository.GetAllNavigation().ToList();

            if (filters.filter != null)
            {
                obj = obj.
                       Where(   x => ( x.Nombre.ToLower().Trim() +" "+ x.ApellidoPaterno.ToLower().Trim() +" "+ x.ApellidoMaterno.ToLower().Trim() ).Contains(filters.filter.ToLower().Trim())
                       || x.Ci.ToLower().Trim() == filters.filter.ToLower().Trim() || x.CategoriaNavigation.Descripcion.ToLower().Contains(filters.filter.ToLower()) || x.ClubNavigation.Descripcion.ToLower().Contains(filters.filter.ToLower())
                       ).ToList();
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



        public async Task<string> GuardarImagen(IFormFile file)
        {

            var path = string.Empty;
            var path2 = string.Empty;

            if (file != null && file.Length > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var file2 = $"{guid}.jpg";


                path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "MyStaticFiles/images",
                    file2);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                path2 = $"StaticFiles/images/{file2}";

                return path2;
            }
            return path2;

        }
        public async Task<string> GuardarHuella(IFormFile file)
        {

            var path = string.Empty;
            var path2 = string.Empty;

            if (file != null && file.Length > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var file2 = $"{guid}.jpg";


                path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "MyStaticFiles/huellas",
                    file2);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                path2 = $"StaticFiles/huellas/{file2}";

                return path2;
            }
            return path2;

        }
    }
}
