using FluentValidation;
using OrderMicroservice.Application.Orders.Dtos;

namespace OrderMicroservice.Application.Validators
{
    public class CreateOrderDtoValidator
        : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0);

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("La orden debe tener al menos un ítem.");

            RuleForEach(x => x.Items)
                .ChildRules(items =>
                {
                    items.RuleFor(i => i.ProductId).GreaterThan(0);
                    items.RuleFor(i => i.Quantity).GreaterThan(0);
                });
        }
    }
}
