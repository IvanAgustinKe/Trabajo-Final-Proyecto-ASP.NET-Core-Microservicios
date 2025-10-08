using MediatR;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product?>;
}
