using MediatR;
using AutoMapper;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.ValueObjects;
using OrderMicroservice.Application.Orders.Dtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderMicroservice.Application.Orders.Commands
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerServiceClient _custClient;
        private readonly IProductServiceClient _prodClient;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            ICustomerServiceClient custClient,
            IProductServiceClient prodClient,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _custClient = custClient;
            _prodClient = prodClient;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(
            CreateOrderCommand request,
            CancellationToken ct)
        {
            
            if (!await _custClient.CustomerExistsAsync(request.CustomerId))
                throw new KeyNotFoundException("Customer not found.");

            
            var vos = new List<OrderItem>();
            foreach (var it in request.Items)
            {
                var prod = await _prodClient.GetProductByIdAsync(it.ProductId);
                if (it.Quantity > prod.Stock)
                    throw new InvalidOperationException($"Insufficient stock for product {it.ProductId}.");
                vos.Add(new OrderItem(prod.Id, prod.Name, prod.Price, it.Quantity));
            }

            
            var order = new Order(request.CustomerId, vos);
            var saved = await _orderRepo.AddAsync(order);

            
            foreach (var vo in vos)
            {
                int newStock = (await _prodClient.GetProductByIdAsync(vo.ProductId)).Stock
                               - vo.Quantity;
                await _prodClient.UpdateProductStockAsync(vo.ProductId, newStock);
            }

            
            return _mapper.Map<OrderDto>(saved);
        }
    }
}
