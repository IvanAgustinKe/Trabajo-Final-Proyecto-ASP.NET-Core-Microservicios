using MediatR;
using CustomerMicroservice.Application.Customers.Queries;
using CustomerMicroservice.Domain.Entities;
using CustomerMicroservice.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerMicroservice.Application.Customers.Queries
{
    public class GetAllCustomersQueryHandler
        : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _repo;
        public GetAllCustomersQueryHandler(ICustomerRepository repo) =>
            _repo = repo;

        public async Task<IEnumerable<Customer>> Handle(
            GetAllCustomersQuery request,
            CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
