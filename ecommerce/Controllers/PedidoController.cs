using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TbPedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            await _pedidoService.InsertAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.PedidoId }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TbPedido pedido)
        {
            if (pedido == null || pedido.PedidoId != id)
                return BadRequest();

            var existingPedido = await _pedidoService.GetByIdAsync(id);
            if (existingPedido == null)
                return NotFound();

            await _pedidoService.UpdateAsync(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPedido = await _pedidoService.GetByIdAsync(id);
            if (existingPedido == null)
                return NotFound();

            await _pedidoService.DeleteAsync(id);
            return NoContent();
        }

    }
}
