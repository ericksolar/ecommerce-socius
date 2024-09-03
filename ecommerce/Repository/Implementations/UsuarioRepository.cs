using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DapperContext _context;

        public UsuarioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbUsuario>> GetAllAsync()
        {
            var query = "SELECT * FROM TbUsuario";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TbUsuario>(query);
            }
        }

        public async Task<TbUsuario> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM TbUsuario WHERE UsuarioId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbUsuario>(query, new { Id = id });
            }
        }

        public async Task<int> InsertAsync(TbUsuario usuario)
        {
            var query = "INSERT INTO TbUsuario (Nombre, Email, Password, EsAdmin, Eliminado, Habilitado) VALUES (@Nombre, @Email, @Password, @EsAdmin, @Eliminado, @Habilitado)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, usuario);
            }
        }

        public async Task<int> UpdateAsync(TbUsuario usuario)
        {
            var query = "UPDATE TbUsuario SET Nombre = @Nombre, Email = @Email, Password = @Password, EsAdmin = @EsAdmin, Eliminado = @Eliminado, Habilitado = @Habilitado WHERE UsuarioId = @UsuarioId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, usuario);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM TbUsuario WHERE UsuarioId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
