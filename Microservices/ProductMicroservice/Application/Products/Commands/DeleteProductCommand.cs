using MediatR;

namespace ProductMicroservice.Application.Products.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<Unit>;
}
