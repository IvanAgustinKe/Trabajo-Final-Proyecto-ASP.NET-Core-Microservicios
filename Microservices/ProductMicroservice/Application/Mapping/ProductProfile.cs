using AutoMapper;
using ProductMicroservice.Application.Products.Commands;
using ProductMicroservice.Application.Products.Dtos;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            
            CreateMap<Product, ProductDto>();

            
            CreateMap<CreateProductDto, CreateProductCommand>();
            CreateMap<UpdateProductDto, UpdateProductCommand>();
        }
    }
}
