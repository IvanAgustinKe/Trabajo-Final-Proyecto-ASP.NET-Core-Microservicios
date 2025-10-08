using FluentValidation;
using CustomerMicroservice.Application.Customers.Dtos;

namespace CustomerMicroservice.Application.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
