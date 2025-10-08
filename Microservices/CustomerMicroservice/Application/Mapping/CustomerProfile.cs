using AutoMapper;
using CustomerMicroservice.Application.Customers.Dtos;
using CustomerMicroservice.Domain.Entities;

namespace CustomerMicroservice.Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
