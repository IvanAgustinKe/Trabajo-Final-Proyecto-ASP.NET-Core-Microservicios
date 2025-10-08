using MediatR;
using CustomerMicroservice.Domain.Entities;

namespace CustomerMicroservice.Application.Customers.Queries
{
    public record GetCustomerByIdQuery(int Id) : IRequest<Customer?>;
}
