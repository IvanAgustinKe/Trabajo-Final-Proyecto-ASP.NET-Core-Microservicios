using MediatR;
using CustomerMicroservice.Application.Interfaces;
using CustomerMicroservice.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerMicroservice.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandler
        : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly ICustomerRepository _repo;
        public GetCustomerByIdQueryHandler(ICustomerRepository repo) =>
            _repo = repo;

        public async Task<Customer?> Handle(
            GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
