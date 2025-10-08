using MediatR;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public record DeleteCustomerCommand(int Id) : IRequest<Unit>;
}
