using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Producto;
using FluentValidation;

namespace WebApp.Validators.Producto
{
    public class ProductoValidator : AbstractValidator<ProductoModel>
    {
        public ProductoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo nombre es requerido")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Unidad)
                .NotEmpty().WithMessage("El campo unidad es requerido")
                .MaximumLength(100).WithMessage("El unidad no puede exceder los 100 caracteres.");
        }
    }
}