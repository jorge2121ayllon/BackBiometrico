using AutoMapper;
using backend.Api.Response;
using backend.Core.CustomEntities;
using backend.Core.DTOs;
using backend.Core.Enumerations;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Core.Services;
using backend.Infraestructure.Entities;
using backend.Infraestructure.Interfaces;
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
    public class ClubController : ControllerBase
    {
        private readonly IClubService _service;
        private readonly IMapper _mapper;
        public ClubController(IClubService clubService, IMapper mapper)
        {
            this._service = clubService;
            this._mapper = mapper;
        }


        [HttpGet("gets")]
        public IActionResult Gets([FromQuery] PostQueryFilter filters)
        {
            var obj = _service.Gets(filters);
            var objDto = _mapper.Map<IEnumerable<ClubDto>>(obj);

            var metadata = new MetaData
            {
                TotalCount = obj.TotalCount,
                PageSize = obj.PageSize,
                CurrentPage = obj.CurrentPage,
                TotalPages = obj.TotalPages,
                HasNextPage = obj.HasNextPage,
                HasPreviousPage = obj.HasPreviousPage,
            };

            var response = new ApiResponse<IEnumerable<ClubDto>>(objDto)
            {
                Meta = metadata
            };
            return Ok(response);

        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _service.Get(id);
            var objDto = _mapper.Map<ClubDto>(obj);
            var response = new ApiResponse<ClubDto>(objDto);

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(ClubDto objDto)
        {
            var obj = _mapper.Map<Club>(objDto);

            await _service.Add(obj);

            objDto = _mapper.Map<ClubDto>(obj);
            var response = new ApiResponse<ClubDto>(objDto);
            return Ok(response);
        }

        [HttpPut("update")]
        public IActionResult Put(ClubDto objDto)
        {

            var obj = _mapper.Map<Club>(objDto);
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
    }
}
