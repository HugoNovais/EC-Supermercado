using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Pagination;

namespace Ec_Supermercado.Api.Services.CategoriaService
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTOTwo>> GetCategorias();
        Task<IEnumerable<CategoriaDTO>> GetProdutosPorCategoria();
        Task<PagedList<CategoriaDTOTwo>> GetParamsCategoria(int pageNumber, int pageSize);
        Task<CategoriaDTO>GetCategoriaById(int id);
        Task AddCategoria(CategoriaDTOTwo categoriaDto);
        Task UpdateCategoria(CategoriaDTOTwo categoriaDto);
        Task DeleteCategoria(int id);
        
    }
}
