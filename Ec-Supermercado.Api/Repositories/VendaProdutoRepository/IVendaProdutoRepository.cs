using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.Repositories.VendaProdutoRepository
{
    public interface IVendaProdutoRepository
    {
        Task<IEnumerable<VendaProduto>> GetAll();
       
        Task<VendaProduto> GetById(int id);
        Task<VendaProduto> Create(VendaProduto vendaProduto);
        Task<VendaProduto> Update(VendaProduto vendaProduto);
        Task<VendaProduto> DeleteById(int id);
    }
}
