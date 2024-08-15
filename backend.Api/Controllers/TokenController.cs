using Microsoft.Extensions.Configuration;
using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public TokenController(IConfiguration configuration, IUserService userService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticationAsync(UserLogin login)
        {
            try
            {

                var validation = await IsValidUser(login);
                if (validation.Item1 == true)
                {
                    var Role = validation.Item2.Rol.ToString();
                    var token = GenerateToken(validation.Item2);
                    return Ok(new
                    {
                        token,
                        Role,
                        validation.Item2.NombreUsuario,
                        validation.Item2.Gmail
                    });

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }


        }

        private async Task<(bool, User)> IsValidUser(UserLogin login)
        {
            try
            {
                var user = await _userService.GetLoginByCredentials(login);
                if (user == null)
                {
                    return (false, user);
                }
                var isValid = _passwordService.Check(user.Clave, login.Password);
                return (isValid, user);
            }
            catch (Exception)
            {

                throw;
            }


        }

        private string GenerateToken(User user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim("User", user.NombreUsuario),
                new Claim(ClaimTypes.Role, user.Rol.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
