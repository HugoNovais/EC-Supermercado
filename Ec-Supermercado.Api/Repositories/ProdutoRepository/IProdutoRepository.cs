using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Repositories.ProdutoRepository
{
    public interface IProdutoRepository
    {
        Task<PagedList<Produto>> GetParamsAsync(int pageNumber, int pageSize);
        Task<PagedList<Produto>> GetParamsNomeAsync(string nome, int pageNumber, int pageSize);
        Task<Produto> InativaProduto(int id);
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<Produto> Delete(int id);
    }
}
