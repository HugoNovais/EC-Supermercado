using Ec_Supermercado.Api.DataContext;
using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.Repositories.VendaRepository
{
    public class VendaRepository : IVendaRepository
    {

        private readonly AppDbContext _appDbContext;

        public VendaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Venda>> GetAll()
        {
            return await _appDbContext.Vendas.ToListAsync();
        }

      

        public async Task<Venda> GetById(int id)
        {
            return await _appDbContext.Vendas.Where(c => c.VendaId == id).FirstOrDefaultAsync();
        }

        public async Task<Venda> Create(Venda venda)
        {
            _appDbContext.Vendas.Add(venda);
            await _appDbContext.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> Update(Venda venda)
        {
            _appDbContext.Vendas.Entry(venda).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> Delete(int id)
        {
            var venda = await GetById(id);
            if (venda == null) throw new Exception("Não foi possível localizar Venda");       
            _appDbContext.Vendas.Remove(venda);
            await _appDbContext.SaveChangesAsync();
            return venda;
        }

  
    }
}
