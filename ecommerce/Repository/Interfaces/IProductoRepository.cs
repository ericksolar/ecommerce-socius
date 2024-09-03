using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<TbProducto>> GetAllAsync();
        Task<TbProducto> GetByIdAsync(int id);
        Task<int> InsertAsync(TbProducto producto);
        Task<int> UpdateAsync(TbProducto producto);
        Task<int> DeleteAsync(int id);
    }

}
