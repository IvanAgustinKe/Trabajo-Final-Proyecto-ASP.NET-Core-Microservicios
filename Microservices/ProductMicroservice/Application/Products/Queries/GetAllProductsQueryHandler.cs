using MediatR;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Products.Queries
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repo;
        public GetAllProductsQueryHandler(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetAllAsync();
    }
}
