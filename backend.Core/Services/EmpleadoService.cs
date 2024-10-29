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
    public class EmpleadoService //: IEmpleadoService
    {
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly PaginationOptions _paginationOptions;
    //    public EmpleadoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    //    {
    //        _unitOfWork = unitOfWork;
    //        this._paginationOptions = options.Value;
    //    }
    //    public async Task Add(Empleado empleado)
    //    {
    //        await _unitOfWork.EmpleadoRepository.Add(empleado);
    //        await _unitOfWork.SaveChangesAsync();
    //    }

    //    public async Task<bool> Delete(int id)
    //    {
    //        await _unitOfWork.EmpleadoRepository.Delete(id);
    //        _unitOfWork.SaveChanges();
    //        return true;
    //    }

       
    //    public async Task<bool> DeleteFingerPrint(string nombre)
    //    {
    //        await _unitOfWork.EmpleadoRepository.DeleteFingerprint(nombre);
    //        _unitOfWork.SaveChanges();
    //        return true;
    //    }

    //    public async Task<Empleado> Get(int id)
    //    {
    //        return await _unitOfWork.EmpleadoRepository.GetById(id);
    //    }

    //    public PagedList<Empleado> Gets(PostQueryFilter filters)
    //    {
    //        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
    //        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

    //        var obj = _unitOfWork.EmpleadoRepository.GetAll().ToList();

    //        if (filters.filter != null)
    //        {
    //            obj = obj.Where(x => x.Nombre.ToLower().Contains(filters.filter.ToLower())).ToList();
    //        }

    //        var pageobj = PagedList<Empleado>.Create(obj, filters.PageNumber, filters.PageSize);

    //        return pageobj;
    //    }

    //    public bool Update(Empleado empleado)
    //    {
    //        _unitOfWork.EmpleadoRepository.Update(empleado);
    //        _unitOfWork.SaveChanges();
    //        return true;
    //    }
    }
}
