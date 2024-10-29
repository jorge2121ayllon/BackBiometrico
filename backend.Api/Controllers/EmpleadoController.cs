using AutoMapper;
using backend.Api.Response;
using backend.Core.CustomEntities;
using backend.Core.DTOs;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Infraestructure.Data;
using backend.Infraestructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        //private readonly IEmpleadoService _service;
        //private readonly IMapper _mapper;
        private readonly InversionContext _context;
        public EmpleadoController( InversionContext context)
        {
            //this._service = service;
            //this._mapper = mapper;
            this._context = context;
        }
        //[HttpGet("gets")]
        //public IActionResult Gets([FromQuery] PostQueryFilter filters)
        //{
        //    var obj = _service.Gets(filters);
        //    var objDto = _mapper.Map<IEnumerable<EmpleadoDto>>(obj);

        //    var metadata = new MetaData
        //    {
        //        TotalCount = obj.TotalCount,
        //        PageSize = obj.PageSize,
        //        CurrentPage = obj.CurrentPage,
        //        TotalPages = obj.TotalPages,
        //        HasNextPage = obj.HasNextPage,
        //        HasPreviousPage = obj.HasPreviousPage,
        //    };

        //    var response = new ApiResponse<IEnumerable<EmpleadoDto>>(objDto)
        //    {
        //        Meta = metadata
        //    };
        //    return Ok(response);

        //}

        //[HttpGet("get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var obj = await _service.Get(id);
        //    var objDto = _mapper.Map<EmpleadoDto>(obj);
        //    var response = new ApiResponse<EmpleadoDto>(objDto);

        //    return Ok(response);
        //}

        //[HttpPost("add")]
        //public async Task<IActionResult> Post(EmpleadoDto objDto)
        //{
        //    var obj = _mapper.Map<Empleado>(objDto);

        //    await _service.Add(obj);

        //    objDto = _mapper.Map<EmpleadoDto>(obj);
        //    var response = new ApiResponse<EmpleadoDto>(objDto);
        //    return Ok(response);
        //}

        //[HttpPut("update")]
        //public IActionResult Put(EmpleadoDto objDto)
        //{

        //    var obj = _mapper.Map<Empleado>(objDto);
        //    obj.Id = objDto.Id;

        //    var result = _service.Update(obj);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string nombre)
        {
            var estado = true;
            var lista= _context.Empleado.Where(a => a.Nombre == nombre).ToList();
            if (lista.Count == 0)
                estado = false;
            foreach (var item in lista)
            {
                var resp = _context.Empleado.Remove(item);
            }
            _context.SaveChanges();
            var response = new ApiResponse<bool>(estado);
            //var result = await _service.DeleteFingerPrint(nombre);
            //var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
