using Ec_Supermercado.Api.DTOs;

using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> GetUsuarioById(int id);
        Task<IEnumerable<UsuarioDTO>> GetVendasPorUsuarios();
        Task<PagedList<UsuarioDTO>> GetParamsUsuario(int pageNumber, int pageSize);
        Task<PagedList<UsuarioDTO>> GetParamsNomeUsuario(string nome, int pageNumber, int pageSize);
        Task<UsuarioDTO> InativaUsuarioById(int id);
        Task AddUsuario(UsuarioDTO usuarioDto);
        Task UpdateUsuario(UsuarioDTO usuarioDto);
        Task DeleteUsuario(int id);
    }
}
