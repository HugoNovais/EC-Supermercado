using Ec_Supermercado.Api.DataContext;
using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.Repositories.CategoriaRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _appDbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _appDbContext.Categorias.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await _appDbContext.Categorias.Include(c => c.Produtos).ToListAsync();
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _appDbContext.Categorias.Add(categoria);
            await _appDbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _appDbContext.Entry(categoria).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Delete(int id)
        {
            var category = await GetById(id);
            _appDbContext.Categorias.Remove(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }



    }
}
