using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoPedidoController : Controller
    {
        private readonly IEstadoPedidoService _estadoPedidoService;

        public EstadoPedidoController(IEstadoPedidoService estadoPedidoService)
        {
            _estadoPedidoService = estadoPedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estadosPedido = await _estadoPedidoService.GetAllAsync();
            return Ok(estadosPedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estadoPedido = await _estadoPedidoService.GetByIdAsync(id);
            if (estadoPedido == null)
                return NotFound();

            return Ok(estadoPedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TbEstadoPedido estadoPedido)
        {
            if (estadoPedido == null)
                return BadRequest();

            await _estadoPedidoService.InsertAsync(estadoPedido);
            return CreatedAtAction(nameof(GetById), new { id = estadoPedido.EstadoId }, estadoPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TbEstadoPedido estadoPedido)
        {
            if (estadoPedido == null || estadoPedido.EstadoId != id)
                return BadRequest();

            var existingEstadoPedido = await _estadoPedidoService.GetByIdAsync(id);
            if (existingEstadoPedido == null)
                return NotFound();

            await _estadoPedidoService.UpdateAsync(estadoPedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEstadoPedido = await _estadoPedidoService.GetByIdAsync(id);
            if (existingEstadoPedido == null)
                return NotFound();

            await _estadoPedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
