using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class PedidoDetalleService : IPedidoDetalleService
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;

        public PedidoDetalleService(IPedidoDetalleRepository pedidoDetalleRepository)
        {
            _pedidoDetalleRepository = pedidoDetalleRepository;
        }

        public async Task<IEnumerable<TbPedidoDetalle>> GetAllAsync()
        {
            return await _pedidoDetalleRepository.GetAllAsync();
        }

        public async Task<TbPedidoDetalle> GetByIdAsync(int pedidoId, int productoId)
        {
            return await _pedidoDetalleRepository.GetByIdAsync(pedidoId, productoId);
        }

        public async Task<int> InsertAsync(TbPedidoDetalle pedidoDetalle)
        {
            return await _pedidoDetalleRepository.InsertAsync(pedidoDetalle);
        }

        public async Task<int> UpdateAsync(TbPedidoDetalle pedidoDetalle)
        {
            return await _pedidoDetalleRepository.UpdateAsync(pedidoDetalle);
        }

        public async Task<int> DeleteAsync(int pedidoId, int productoId)
        {
            return await _pedidoDetalleRepository.DeleteAsync(pedidoId, productoId);
        }
    }
}
