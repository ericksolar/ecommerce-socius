using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IEstadoPedidoService
    {
        Task<IEnumerable<TbEstadoPedido>> GetAllAsync();
        Task<TbEstadoPedido> GetByIdAsync(int id);
        Task<int> InsertAsync(TbEstadoPedido estadoPedido);
        Task<int> UpdateAsync(TbEstadoPedido estadoPedido);
        Task<int> DeleteAsync(int id);
    }
}
