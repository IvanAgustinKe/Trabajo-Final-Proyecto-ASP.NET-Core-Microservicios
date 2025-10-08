using MediatR;
using ProductMicroservice.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Products.Commands
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, Unit>   
    {
        private readonly IProductRepository _repo;
        public DeleteProductCommandHandler(IProductRepository repo) =>
            _repo = repo;

        public async Task<Unit> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;                             
        }
    }
}
