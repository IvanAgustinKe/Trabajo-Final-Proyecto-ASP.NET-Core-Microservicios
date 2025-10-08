using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.Orders.Commands;
using OrderMicroservice.Application.Orders.Queries;
using OrderMicroservice.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(dtos);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var dto = await _mediator.Send(new GetOrderByIdQuery(id));
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderDto dto)
        {
            var cmd = new CreateOrderCommand(dto.CustomerId, dto.Items);
            var created = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
