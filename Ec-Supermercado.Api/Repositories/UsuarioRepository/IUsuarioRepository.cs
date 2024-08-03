using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Repositories.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetUsuarioVenda();
        Task<PagedList<Usuario>> GetParamsAsync(int pageNumber, int pageSize);
        Task<PagedList<Usuario>> GetParamsNomeAsync(string nome, int pageNumber, int pageSize);
        
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmailSenha(string email, string senha);
        Task<Usuario> InativaUsuario(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(int id);
    }
}
