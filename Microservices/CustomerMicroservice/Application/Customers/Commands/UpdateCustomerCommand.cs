using MediatR;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public record UpdateCustomerCommand(
        int Id,
        string Name,
        string Email,
        string Address
    ) : IRequest<Unit>;
}
