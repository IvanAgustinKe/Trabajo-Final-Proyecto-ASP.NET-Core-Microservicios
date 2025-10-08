using MediatR;
using AutoMapper;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Application.Orders.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMicroservice.Application.Orders.Queries
{
    public class GetOrderByIdQueryHandler
        : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OrderDto?> Handle(
            GetOrderByIdQuery request,
            CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id);
            return entity is null
                ? null
                : _mapper.Map<OrderDto>(entity);
        }
    }
}
