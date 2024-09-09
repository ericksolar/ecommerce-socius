using ecommerce.Model;
using ecommerce.Repository.Implementations;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ecommerce.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IProductoRepository productoRepository, ILogger<UsuarioService> logger)
        {
            _productoRepository = productoRepository;
            _logger = logger;

        }

        public async Task<IEnumerable<TbProducto>> GetAllAsync()
        {
            try
            {
                return await _productoRepository.GetAllAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Productos no encontrados");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los productos");
                throw new ApplicationException("Ocurrió un error al obtener los productos", ex);
            }
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