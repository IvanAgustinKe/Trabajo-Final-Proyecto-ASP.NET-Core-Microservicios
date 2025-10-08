using MediatR;
using AutoMapper;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMicroservice.Application.Orders.Queries
{
    public class GetAllOrdersQueryHandler
        : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(
            GetAllOrdersQuery request,
            CancellationToken ct)
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(list);
        }
    }
}
