using backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Rol).NotNull();
            RuleFor(p => p.Clave).NotNull().Length(5, 100);
            RuleFor(p => p.Gmail).NotNull();
            RuleFor(p => p.NombreUsuario).NotNull();
        }
    }
}
