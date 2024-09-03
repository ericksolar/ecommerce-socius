using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class EstadoPedidoService : IEstadoPedidoService
    {
        private readonly IEstadoPedidoRepository _estadoPedidoRepository;
        public EstadoPedidoService(IEstadoPedidoRepository estadoPedidoRepository)
        {
            _estadoPedidoRepository = estadoPedidoRepository;
        }

        public async Task<IEnumerable<TbEstadoPedido>> GetAllAsync()
        {
            return await _estadoPedidoRepository.GetAllAsync();
        }

        public async Task<TbEstadoPedido> GetByIdAsync(int id)
        {
            return await _estadoPedidoRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(TbEstadoPedido estadoPedido)
        {
            return await _estadoPedidoRepository.InsertAsync(estadoPedido);
        }

        public async Task<int> UpdateAsync(TbEstadoPedido estadoPedido)
        {
            return await _estadoPedidoRepository.UpdateAsync(estadoPedido);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _estadoPedidoRepository.DeleteAsync(id);
        }
    }
}
