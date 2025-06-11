using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApp.Models.Usuarios;

namespace WebApp.Validators.Usuarios
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("El campo usuario es requerido")
                .Matches("^[a-zA-z0-9]+$").WithMessage("El nombre de usuario no debe contener espacios ni caracteres especiales")
                .MinimumLength(4).WithMessage("El nombre de usuario debe tener al menos 4 caracteres")
                .MaximumLength(20).WithMessage("el nombre de usuario no puede exceder los 20 caracteres");

            RuleFor(x => x.Contrasenia)
                .NotEmpty().WithMessage("El campo contraseña es requerido")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$")
                .WithMessage("La contraseña debe tener al menos una mayúscula, minúscula, número, carácter especial y mínimo 6 caracteres.");
        }
    }
}