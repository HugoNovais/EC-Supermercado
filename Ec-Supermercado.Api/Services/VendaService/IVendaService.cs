using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Services.VendaService
{
    public interface IVendaService
    {
        Task<IEnumerable<VendaDTOTwo>> GetVendas();
        Task<IEnumerable<VendaDTO>> GetVendasPorVendaProduto();
        Task<PagedList<VendaDTOTwo>> GetParamsVendas(int pageNumber, int pageSize);
        Task<VendaDTO> GetVendasById(int id);
        Task AddVenda(VendaDTOTwo vendaDTO);
        Task Update(VendaDTO vendaDTO);
        Task Delete(int id);
    }
}
