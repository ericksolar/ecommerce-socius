using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DapperContext _context;

        public ProductoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbProducto>> GetAllAsync()
        {
            var query = "SELECT * FROM TbProducto";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TbProducto>(query);
            }
        }

        public async Task<TbProducto> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM TbProducto WHERE ProductoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbProducto>(query, new { Id = id });
            }
        }

        public async Task<int> InsertAsync(TbProducto producto)
        {
            var query = "INSERT INTO TbProducto (Nombre, Descripcion, Precio, Stock, StockReservado, Habilitado, Eliminado) VALUES (@Nombre, @Descripcion, @Precio, @Stock, @StockReservado, @Habilitado, @Eliminado)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, producto);
            }
        }

        public async Task<int> UpdateAsync(TbProducto producto)
        {
            var query = "UPDATE TbProducto SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, StockReservado = @StockReservado, Habilitado = @Habilitado, Eliminado = @Eliminado WHERE ProductoId = @ProductoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, producto);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM TbProducto WHERE ProductoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
