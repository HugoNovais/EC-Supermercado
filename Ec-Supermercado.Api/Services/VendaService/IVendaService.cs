using Ec_Supermercado.Api.DTOs;

namespace Ec_Supermercado.Api.Services.VendaService
{
    public interface IVendaService
    {
        Task<IEnumerable<VendaDTO>> GetVendas();
        Task<IEnumerable<VendaDTO>> GetVendasPorVendaProduto();
        Task<VendaDTO> GetVendasById(int id);
        Task AddVenda(VendaDTOTwo vendaDTO);
        Task Update(VendaDTO vendaDTO);
        Task Delete(int id);
    }
}
