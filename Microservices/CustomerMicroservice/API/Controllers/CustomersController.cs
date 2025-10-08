using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerMicroservice.Application.Customers.Commands;
using CustomerMicroservice.Application.Customers.Dtos;
using CustomerMicroservice.Application.Customers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var entities = await _mediator.Send(new GetAllCustomersQuery());
            var dtos = _mapper.Map<IEnumerable<CustomerDto>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var entity = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<CustomerDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto dto)
        {
            
            var cmd = new CreateCustomerCommand(
                dto.Name,
                dto.Email,
                dto.Address,
                DateTime.UtcNow
            );
            var created = await _mediator.Send(cmd);
            var result = _mapper.Map<CustomerDto>(created);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.Id) return BadRequest();
            
            var cmd = new UpdateCustomerCommand(
                dto.Id,
                dto.Name,
                dto.Email,
                dto.Address
            );
            await _mediator.Send(cmd);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }
    }
}
