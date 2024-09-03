using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<TbUsuario>> GetAllAsync();
        Task<TbUsuario> GetByIdAsync(int id);
        Task<int> InsertAsync(TbUsuario usuario);
        Task<int> UpdateAsync(TbUsuario usuario);
        Task<int> DeleteAsync(int id);
    }
}
