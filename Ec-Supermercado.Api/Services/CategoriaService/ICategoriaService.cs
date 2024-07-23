using Ec_Supermercado.Api.DTOs;

namespace Ec_Supermercado.Api.Services.CategoriaService
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTOTwo>> GetCategorias();
        Task<IEnumerable<CategoriaDTO>> GetProdutosPorCategoria();
        Task<CategoriaDTO>GetCategoriaById(int id);
        Task AddCategoria(CategoriaDTOTwo categoriaDto);
        Task UpdateCategoria(CategoriaDTOTwo categoriaDto);
        Task DeleteCategoria(int id);
        
    }
}
