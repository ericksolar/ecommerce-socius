using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DapperContext _context;

        public PedidoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbPedido>> GetAllAsync()
        {
            var query = "SELECT * FROM TbPedido";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TbPedido>(query);
            }
        }

        public async Task<TbPedido> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM TbPedido WHERE PedidoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbPedido>(query, new { Id = id });
            }
        }

        public async Task<int> InsertAsync(TbPedido pedido)
        {
            var query = "INSERT INTO TbPedido (UsuarioId, EstadoId, ValorTotal, Fecha, Eliminado) VALUES (@UsuarioId, @EstadoId, @ValorTotal, @Fecha, @Eliminado)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, pedido);
            }
        }

        public async Task<int> UpdateAsync(TbPedido pedido)
        {
            var query = "UPDATE TbPedido SET UsuarioId = @UsuarioId, EstadoId = @EstadoId, ValorTotal = @ValorTotal, Fecha = @Fecha, Eliminado = @Eliminado WHERE PedidoId = @PedidoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, pedido);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM TbPedido WHERE PedidoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
