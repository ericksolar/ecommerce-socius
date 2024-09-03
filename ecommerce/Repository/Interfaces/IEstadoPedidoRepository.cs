using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IEstadoPedidoRepository
    {
        Task<IEnumerable<TbEstadoPedido>> GetAllAsync();
        Task<TbEstadoPedido> GetByIdAsync(int id);
        Task<int> InsertAsync(TbEstadoPedido estadoPedido);
        Task<int> UpdateAsync(TbEstadoPedido estadoPedido);
        Task<int> DeleteAsync(int id);
    }
}
