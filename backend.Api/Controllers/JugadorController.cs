using AutoMapper;
using backend.Api.Response;
using backend.Core.CustomEntities;
using backend.Core.DTOs;
using backend.Core.Enumerations;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Infraestructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace backend.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrador))]
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {

        private readonly IJugadorService _service;
        private readonly IMapper _mapper;
        public JugadorController(IJugadorService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet("gets")]
        public IActionResult Gets([FromQuery] PostQueryFilter filters)
        {
            var obj = _service.Gets(filters);
            var objDto = _mapper.Map<IEnumerable<JugadorListDto>>(obj);

            var metadata = new MetaData
            {
                TotalCount = obj.TotalCount,
                PageSize = obj.PageSize,
                CurrentPage = obj.CurrentPage,
                TotalPages = obj.TotalPages,
                HasNextPage = obj.HasNextPage,
                HasPreviousPage = obj.HasPreviousPage,
            };

            var response = new ApiResponse<IEnumerable<JugadorListDto>>(objDto)
            {
                Meta = metadata
            };
            return Ok(response);

        }


        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _service.Get(id);
            var objDto = _mapper.Map<JugadorListDto>(obj);
            var response = new ApiResponse<JugadorListDto>(objDto);

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(JugadorDto objDto)
        {
            var obj = _mapper.Map<Jugador>(objDto);

            await _service.Add(obj);

            objDto = _mapper.Map<JugadorDto>(obj);
            var response = new ApiResponse<JugadorDto>(objDto);
            return Ok(response);
        }

        [HttpPut("update")]
        public IActionResult Put(JugadorDto objDto)
        {

            var obj = _mapper.Map<Jugador>(objDto);
            obj.Id = objDto.Id;

            var result = _service.Update(obj);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarImagen(IFormFile file)
        {
            var result = _service.GuardarImagen(file);
            var response = new ApiResponse<string>(await result);
            return Ok(response);
        }
        [HttpPost("huella")]
        public async Task<IActionResult> GuardarHuella(IFormFile file)
        {
            var result = _service.GuardarHuella(file);
            var response = new ApiResponse<string>(await result);
            return Ok(response);
        }

    }
}
