using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<TbPedido>> GetAllAsync();
        Task<TbPedido> GetByIdAsync(int id);
        Task<int> InsertAsync(TbPedido pedido);
        Task<int> UpdateAsync(TbPedido pedido);
        Task<int> DeleteAsync(int id);

    }
}
