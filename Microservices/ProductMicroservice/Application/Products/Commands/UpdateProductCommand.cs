using MediatR;

namespace ProductMicroservice.Application.Products.Commands
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int Stock
    ) : IRequest<Unit>;
}
