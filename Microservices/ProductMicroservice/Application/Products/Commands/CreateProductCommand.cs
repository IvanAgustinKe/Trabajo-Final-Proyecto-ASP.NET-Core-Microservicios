using MediatR;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Application.Products.Commands
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        int Stock
    ) : IRequest<Product>;
}
