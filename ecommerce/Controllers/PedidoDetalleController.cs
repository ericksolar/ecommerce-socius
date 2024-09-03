using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoDetalleController : Controller
    {
        private readonly IPedidoDetalleService _pedidoDetalleService;
        public PedidoDetalleController(IPedidoDetalleService pedidoDetalleService)
        {
            _pedidoDetalleService = pedidoDetalleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidoDetalles = await _pedidoDetalleService.GetAllAsync();
            return Ok(pedidoDetalles);
        }

        [HttpGet("{pedidoId}/{productoId}")]
        public async Task<IActionResult> GetById(int pedidoId, int productoId)
        {
            var pedidoDetalle = await _pedidoDetalleService.GetByIdAsync(pedidoId, productoId);
            if (pedidoDetalle == null)
                return NotFound();

            return Ok(pedidoDetalle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TbPedidoDetalle pedidoDetalle)
        {
            if (pedidoDetalle == null)
                return BadRequest();

            await _pedidoDetalleService.InsertAsync(pedidoDetalle);
            return CreatedAtAction(nameof(GetById), new { pedidoId = pedidoDetalle.PedidoId, productoId = pedidoDetalle.ProductoId }, pedidoDetalle);
        }

        [HttpPut("{pedidoId}/{productoId}")]
        public async Task<IActionResult> Update(int pedidoId, int productoId, [FromBody] TbPedidoDetalle pedidoDetalle)
        {
            if (pedidoDetalle == null || pedidoDetalle.PedidoId != pedidoId || pedidoDetalle.ProductoId != productoId)
                return BadRequest();

            var existingPedidoDetalle = await _pedidoDetalleService.GetByIdAsync(pedidoId, productoId);
            if (existingPedidoDetalle == null)
                return NotFound();

            await _pedidoDetalleService.UpdateAsync(pedidoDetalle);
            return NoContent();
        }

        [HttpDelete("{pedidoId}/{productoId}")]
        public async Task<IActionResult> Delete(int pedidoId, int productoId)
        {
            var existingPedidoDetalle = await _pedidoDetalleService.GetByIdAsync(pedidoId, productoId);
            if (existingPedidoDetalle == null)
                return NotFound();

            await _pedidoDetalleService.DeleteAsync(pedidoId, productoId);
            return NoContent();
        }

    }
}
