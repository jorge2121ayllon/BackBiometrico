using AutoMapper;
using backend.Api.Response;
using backend.Core.CustomEntities;
using backend.Core.DTOs;
using backend.Core.Entities;
using backend.Core.Enumerations;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Core.Services;
using backend.Infraestructure.Entities;
using backend.Infraestructure.Interfaces;
using backend.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrador))]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            this._categoriaService = categoriaService;
            this._mapper = mapper;
        }


      
        [HttpGet("gets")]
        public IActionResult Gets([FromQuery] PostQueryFilter filters)
        {
            var obj = _categoriaService.Gets(filters);
            var objDto = _mapper.Map<IEnumerable<CategoriaDto>>(obj);

            var metadata = new MetaData
            {
                TotalCount = obj.TotalCount,
                PageSize = obj.PageSize,
                CurrentPage = obj.CurrentPage,
                TotalPages = obj.TotalPages,
                HasNextPage = obj.HasNextPage,
                HasPreviousPage = obj.HasPreviousPage,
            };

            var response = new ApiResponse<IEnumerable<CategoriaDto>>(objDto)
            {
                Meta = metadata
            };
            return Ok(response);

        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _categoriaService.Get(id);
            var objDto = _mapper.Map<CategoriaDto>(obj);
            var response = new ApiResponse<CategoriaDto>(objDto);

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(CategoriaDto objDto)
        {
            var obj = _mapper.Map<Categoria>(objDto);

            await _categoriaService.Add(obj);

            objDto = _mapper.Map<CategoriaDto>(obj);
            var response = new ApiResponse<CategoriaDto>(objDto);
            return Ok(response);
        }

        [HttpPut("update")]
        public IActionResult Put(CategoriaDto objDto)
        {
            
            var obj = _mapper.Map<Categoria>(objDto);
            obj.Id = objDto.Id;

            var result = _categoriaService.Update(obj);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriaService.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
