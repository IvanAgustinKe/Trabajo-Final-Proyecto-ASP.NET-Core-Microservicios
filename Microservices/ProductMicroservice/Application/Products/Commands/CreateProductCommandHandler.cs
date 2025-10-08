using MediatR;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Application.Products.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repo;

        public CreateProductCommandHandler(IProductRepository repo) =>
            _repo = repo;

        public async Task<Product> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };
            await _repo.AddAsync(product);
            return product;
        }
    }
}
