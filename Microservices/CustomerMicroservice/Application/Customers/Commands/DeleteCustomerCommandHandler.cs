using MediatR;
using CustomerMicroservice.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerMicroservice.Application.Customers.Commands
{
    public class DeleteCustomerCommandHandler
        : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repo;
        public DeleteCustomerCommandHandler(ICustomerRepository repo) =>
            _repo = repo;

        public async Task<Unit> Handle(
            DeleteCustomerCommand request,
            CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
