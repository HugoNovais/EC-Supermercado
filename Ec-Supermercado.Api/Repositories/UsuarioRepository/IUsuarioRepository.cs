using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.Repositories.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmailSenha(string email, string senha);
        Task<Usuario> InativaUsuario(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(int id);
    }
}
