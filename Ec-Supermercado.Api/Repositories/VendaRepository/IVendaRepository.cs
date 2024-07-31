using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.Repositories.VendaRepository
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> GetAll();
        Task<Venda> GetById(int id);
        Task<Venda> Create(Venda venda);
        Task<Venda> Update(Venda venda);
        Task<Venda> Delete(int id);
    }
}
