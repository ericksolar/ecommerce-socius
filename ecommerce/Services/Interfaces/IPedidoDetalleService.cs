using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IPedidoDetalleService
    {
        Task<IEnumerable<TbPedidoDetalle>> GetAllAsync();
        Task<TbPedidoDetalle> GetByIdAsync(int pedidoId, int productoId);
        Task<int> InsertAsync(TbPedidoDetalle pedidoDetalle);
        Task<int> UpdateAsync(TbPedidoDetalle pedidoDetalle);
        Task<int> DeleteAsync(int pedidoId, int productoId);
    }
}
