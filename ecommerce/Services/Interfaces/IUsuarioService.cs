using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TbUsuario>> GetAllAsync();
        Task<TbUsuario> GetByIdAsync(int id);
        Task<int> InsertAsync(TbUsuario usuario);
        Task<int> UpdateAsync(TbUsuario usuario);
        Task<int> DeleteAsync(int id);
    }
}
