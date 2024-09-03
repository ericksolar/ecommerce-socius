using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<TbProducto>> GetAllAsync();
        Task<TbProducto> GetByIdAsync(int id);
        Task<int> InsertAsync(TbProducto producto);
        Task<int> UpdateAsync(TbProducto producto);
        Task<int> DeleteAsync(int id);
    }
}
