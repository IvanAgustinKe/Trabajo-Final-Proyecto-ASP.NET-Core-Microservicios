using MediatR;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Products.Commands
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, Unit>    
    {
        private readonly IProductRepository _repo;
        public UpdateProductCommandHandler(IProductRepository repo) =>
            _repo = repo;

        public async Task<Unit> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };
            await _repo.UpdateAsync(product);
            return Unit.Value;                             
        }
    }
}
