using FluentValidation;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar 100 caracteres.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede superar 500 caracteres.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
        }
    }
}
