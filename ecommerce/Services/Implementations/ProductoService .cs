using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<TbProducto>> GetAllAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<TbProducto> GetByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(TbProducto producto)
        {
            return await _productoRepository.InsertAsync(producto);
        }

        public async Task<int> UpdateAsync(TbProducto producto)
        {
            return await _productoRepository.UpdateAsync(producto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _productoRepository.DeleteAsync(id);
        }

    }
}