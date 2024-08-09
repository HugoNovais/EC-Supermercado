using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Repositories.VendaRepository
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> GetAll();
        Task<IEnumerable<Venda>> GetVendaProduto();
        Task<PagedList<Venda>> GetParamsAsync(int pageNumber, int pageSize);
        Task<Venda> GetById(int id);
        Task<Venda> Create(Venda venda);
        Task<Venda> Update(Venda venda);
        Task<Venda> Delete(int id);
    }
}
