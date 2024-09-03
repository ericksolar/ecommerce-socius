using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class PedidoDetalleRepository : IPedidoDetalleRepository
    {
        private readonly DapperContext _context;

        public PedidoDetalleRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbPedidoDetalle>> GetAllAsync()
        {
            var query = "SELECT * FROM TbPedidoDetalle";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TbPedidoDetalle>(query);
            }
        }

        public async Task<TbPedidoDetalle> GetByIdAsync(int pedidoId, int productoId)
        {
            var query = "SELECT * FROM TbPedidoDetalle WHERE PedidoId = @PedidoId AND ProductoId = @ProductoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbPedidoDetalle>(query, new { PedidoId = pedidoId, ProductoId = productoId });
            }
        }

        public async Task<int> InsertAsync(TbPedidoDetalle pedidoDetalle)
        {
            var query = "INSERT INTO TbPedidoDetalle (PedidoId, ProductoId, Cantidad, PrecioTotal) VALUES (@PedidoId, @ProductoId, @Cantidad, @PrecioTotal)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, pedidoDetalle);
            }
        }

        public async Task<int> UpdateAsync(TbPedidoDetalle pedidoDetalle)
        {
            var query = "UPDATE TbPedidoDetalle SET Cantidad = @Cantidad, PrecioTotal = @PrecioTotal WHERE PedidoId = @PedidoId AND ProductoId = @ProductoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, pedidoDetalle);
            }
        }

        public async Task<int> DeleteAsync(int pedidoId, int productoId)
        {
            var query = "DELETE FROM TbPedidoDetalle WHERE PedidoId = @PedidoId AND ProductoId = @ProductoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { PedidoId = pedidoId, ProductoId = productoId });
            }
        }
    }
}
