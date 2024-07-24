using Ec_Supermercado.Api.DataContext;
using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.Repositories.ProdutoRepository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _appDbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _appDbContext.Produtos.Where(c => c.ProdutoId == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> Create(Produto produto)
        {
            _appDbContext.Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Update(Produto produto)
        {
            _appDbContext.Entry(produto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Delete(int id)
        {
            var produto = await GetById(id);
            _appDbContext.Produtos.Remove(produto);
            await _appDbContext.SaveChangesAsync();
            return produto;
        }

      
    }
}
