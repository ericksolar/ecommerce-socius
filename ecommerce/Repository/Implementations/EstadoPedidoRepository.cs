using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class EstadoPedidoRepository : IEstadoPedidoRepository
    {
        private readonly DapperContext _context;

        public EstadoPedidoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbEstadoPedido>> GetAllAsync()
        {
            var query = "SELECT * FROM TbEstadoPedido";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TbEstadoPedido>(query);
            }
        }

        public async Task<TbEstadoPedido> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM TbEstadoPedido WHERE EstadoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbEstadoPedido>(query, new { Id = id });
            }
        }

        public async Task<int> InsertAsync(TbEstadoPedido estadoPedido)
        {
            var query = "INSERT INTO TbEstadoPedido (Nombre) VALUES (@Nombre)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, estadoPedido);
            }
        }

        public async Task<int> UpdateAsync(TbEstadoPedido estadoPedido)
        {
            var query = "UPDATE TbEstadoPedido SET Nombre = @Nombre WHERE EstadoId = @EstadoId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, estadoPedido);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM TbEstadoPedido WHERE EstadoId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}

