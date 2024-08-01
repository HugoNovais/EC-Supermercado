using Ec_Supermercado.Api.DTOs;

namespace Ec_Supermercado.Api.Services.VendaService
{
    public interface IVendaService
    {
        Task<IEnumerable<VendaDTO>> GetVendas();
        Task<VendaDTO> GetVendasById(int id);
        Task AddUsuario(VendaDTO vendaDTO);
        Task Update(VendaDTO vendaDTO);
        Task Delete(int id);
    }
}
