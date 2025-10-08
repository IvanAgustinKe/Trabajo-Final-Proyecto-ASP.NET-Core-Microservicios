using MediatR;
using CustomerMicroservice.Domain.Entities;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public record CreateCustomerCommand(
        string Name,
        string Email,
        string Address,
        DateTime RegisteredAt
    ) : IRequest<Customer>;
}
