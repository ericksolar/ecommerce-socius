using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<TbPedido>> GetAllAsync();
        Task<TbPedido> GetByIdAsync(int id);
        Task<int> InsertAsync(TbPedido pedido);
        Task<int> UpdateAsync(TbPedido pedido);
        Task<int> DeleteAsync(int id);
    }
}
