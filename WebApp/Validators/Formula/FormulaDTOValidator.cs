using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApp.Models.Formula;

namespace WebApp.Validators.Formula
{
    public class FormulaDTOValidator : AbstractValidator<FormulaDTO>
    {
        public FormulaDTOValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo nombre es requerido")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Materiales)
                .NotNull().WithMessage("Debe proporcionar una lista de productos.")
                .Must(m => m.Count > 0).WithMessage("Debe haber al menos un material en la lista.")
                .Must(materiales => materiales.Select(m => m.IdProducto).Distinct().Count() == materiales.Count)
                .WithMessage("No se permiten productos repetidos en la lista de producto.");
        }
    }
}