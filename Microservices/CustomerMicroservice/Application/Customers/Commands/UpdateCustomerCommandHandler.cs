using MediatR;
using CustomerMicroservice.Application.Interfaces;
using CustomerMicroservice.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler
        : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repo;

        public UpdateCustomerCommandHandler(ICustomerRepository repo) =>
            _repo = repo;

        public async Task<Unit> Handle(
            UpdateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
            };
            await _repo.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}
