using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.Repositories.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
        Task<Categoria> GetById(int id);
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Delete(int id);

    }
}
