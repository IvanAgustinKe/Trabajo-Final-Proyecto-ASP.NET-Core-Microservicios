using MediatR;
using CustomerMicroservice.Domain.Entities;
using System.Collections.Generic;

namespace CustomerMicroservice.Application.Customers.Queries
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<Customer>>;
}
