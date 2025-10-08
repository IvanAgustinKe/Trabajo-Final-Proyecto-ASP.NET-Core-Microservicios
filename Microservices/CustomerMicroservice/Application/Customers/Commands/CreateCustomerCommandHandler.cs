using MediatR;
using CustomerMicroservice.Application.Interfaces;
using CustomerMicroservice.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _repo;
        public CreateCustomerCommandHandler(ICustomerRepository repo) =>
            _repo = repo;

        public async Task<Customer> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                RegisteredAt = request.RegisteredAt
            };
            await _repo.AddAsync(customer);
            return customer;
        }
    }
}
