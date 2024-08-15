using AutoMapper;
using backend.Api.Response;
using backend.Core.CustomEntities;
using backend.Core.DTOs;
using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using backend.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public UserController(IUserService userService, IMapper mapper, IPasswordService passwordService)
        {
            this._userService = userService;
            this._mapper = mapper;
            _passwordService = passwordService;

        }

        [HttpGet]
        public IActionResult Get([FromQuery] PostQueryFilter filters)
        {
            var users = _userService.GetUsers(filters);
            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(users);

            var metadata = new MetaData
            {
                TotalCount = users.TotalCount,
                PageSize = users.PageSize,
                CurrentPage = users.CurrentPage,
                TotalPages = users.TotalPages,
                HasNextPage = users.HasNextPage,
                HasPreviousPage = users.HasPreviousPage,
            };

            var response = new ApiResponse<IEnumerable<UserResponseDto>>(usersDto)
            {
                Meta = metadata
            };
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            var userDto = _mapper.Map<UserResponseDto>(user);
            var response = new ApiResponse<UserResponseDto>(userDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.Clave = _passwordService.Hash(user.Clave);
            await _userService.RegisterUser(user);

            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User userDto)
        {
            if (userDto.Clave == null || userDto.Clave == "")
            {
                userDto.Clave = _userService.GetPassword(id);
            }
            else
            {
                userDto.Clave = _passwordService.Hash(userDto.Clave);
            }

            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            var result = _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }



    }
}
