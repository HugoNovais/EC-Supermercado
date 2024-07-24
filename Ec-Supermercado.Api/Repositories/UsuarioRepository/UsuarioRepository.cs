using Ec_Supermercado.Api.DataContext;
using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.Repositories.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
       private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<IEnumerable<Usuario>> GetAll()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await  _appDbContext.Usuarios.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetByEmailSenha(string email, string senha)
        {
            var usuario = await _appDbContext.Usuarios.Where(c => c.Email == email && c.Senha == senha).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _appDbContext.Entry(usuario).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Delete(int id)
        {
            var usuario = await GetById(id);
            _appDbContext.Usuarios.Remove(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

    
    }
}
