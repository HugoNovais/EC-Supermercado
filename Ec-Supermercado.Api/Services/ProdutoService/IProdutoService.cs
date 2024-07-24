using Ec_Supermercado.Api.DTOs;

namespace Ec_Supermercado.Api.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task <ProdutoDTO> GetProdutoById(int id);
        Task AddProduto(ProdutoDTO produtoDTO);

        Task UpdateProduto (ProdutoDTO produtoDTO);
        Task DeleteProduto(int id);
    }
}
