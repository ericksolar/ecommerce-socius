using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<IEnumerable<TbPedido>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task<TbPedido> GetByIdAsync(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(TbPedido pedido)
        {
            return await _pedidoRepository.InsertAsync(pedido);
        }

        public async Task<int> UpdateAsync(TbPedido pedido)
        {
            return await _pedidoRepository.UpdateAsync(pedido);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _pedidoRepository.DeleteAsync(id);
        }
    }
}
