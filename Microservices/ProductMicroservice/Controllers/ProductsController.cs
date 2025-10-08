using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.Products.Commands;
using ProductMicroservice.Application.Products.Dtos;
using ProductMicroservice.Application.Products.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product is null) return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
        {
            var cmd = _mapper.Map<CreateProductCommand>(dto);
            var created = await _mediator.Send(cmd);
            var result = _mapper.Map<ProductDto>(created);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var cmd = _mapper.Map<UpdateProductCommand>(dto);
            await _mediator.Send(cmd);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
