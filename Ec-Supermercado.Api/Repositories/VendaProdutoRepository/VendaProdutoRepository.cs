using Ec_Supermercado.Api.DataContext;
using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.Repositories.VendaProdutoRepository
{
    public class VendaProdutoRepository : IVendaProdutoRepository
    {

        private readonly AppDbContext _appDbContext;

        public VendaProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<VendaProduto>> GetAll()
        {
            return await _appDbContext.VendaProdutos.ToListAsync();
        }

        
        public async Task<VendaProduto> GetById(int id)
        {
            return await _appDbContext.VendaProdutos.Where(c => c.VendaProdutoId == id).FirstOrDefaultAsync();
        }

        /*public async Task<VendaProduto> QuantidadeRetirada(double quantidade)
        {
            var quantidadeRe = await _appDbContext.VendaProdutos.
        }
        */
        public async Task<VendaProduto> Create(VendaProduto vendaProduto)
        {
            var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == vendaProduto.ProdutoId);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            // Verifica se há estoque suficiente
            if (produto.Estoque < vendaProduto.QuantidadeRetirada)
            {
                throw new Exception("Estoque insuficiente");
            }

            // Subtrai a quantidade do estoque
            produto.Estoque -= vendaProduto.QuantidadeRetirada;

            // Adiciona o VendaProduto no contexto
            _appDbContext.VendaProdutos.Add(vendaProduto);

            // Salva as mudanças no banco de dados
            await _appDbContext.SaveChangesAsync();

            return vendaProduto;
        }


        public async Task<VendaProduto> Update(VendaProduto vendaProduto)
        {
            _appDbContext.VendaProdutos.Entry(vendaProduto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return vendaProduto; 
        }

        public async Task<VendaProduto> DeleteById(int id)
        {
            var vendaProduto = await GetById(id);
            _appDbContext.VendaProdutos.Remove(vendaProduto);
            await _appDbContext.SaveChangesAsync();
            return vendaProduto;
        }


    }
}
