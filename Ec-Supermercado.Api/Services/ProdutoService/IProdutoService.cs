using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task <ProdutoDTO> GetProdutoById(int id);
        Task<PagedList<ProdutoDTO>> GetParamsProduto(int pageNumber,  int pageSize);
        Task<PagedList<ProdutoDTO>> GetParamsProdutoNome(string nome, int pageNumber, int pageSize);
        Task AddProduto(ProdutoDTO produtoDTO);

        Task UpdateProduto (ProdutoDTO produtoDTO);
        Task DeleteProduto(int id);
    }
}
