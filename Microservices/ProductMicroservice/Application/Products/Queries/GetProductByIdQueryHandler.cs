using MediatR;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Products.Queries
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly IProductRepository _repo;
        public GetProductByIdQueryHandler(IProductRepository repo) => _repo = repo;

        public async Task<Product?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetByIdAsync(request.Id);
    }
}
