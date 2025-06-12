using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.FormulaMateriales;
using FluentValidation;

namespace WebApp.Validators.Formula
{
    public class FormulaMaterialesModelValidator : AbstractValidator<FormulaMaterialesModel>
    {
        public FormulaMaterialesModelValidator()
        {
            RuleFor(x => x.IdProducto)
                .GreaterThan(0).WithMessage("El ID del producto no es valido.");

            RuleFor(x => x.Cantidad)
                .GreaterThan(0).WithMessage("La cantidad del producto debe ser mayor que cero.");
        }
    }
}