using MediatR;
using ProductMicroservice.Domain.Entities;
using System.Collections.Generic;

namespace ProductMicroservice.Application.Products.Queries
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
}
