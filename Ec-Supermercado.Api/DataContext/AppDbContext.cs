using Ec_Supermercado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ec_Supermercado.Api.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaProduto> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(c => c.CategoryId);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
            .HasKey(v => v.VendaId);

            modelBuilder.Entity<Venda>()
                .HasMany(vp => vp.VendaProdutos)
                .WithOne(x => x.Venda)
                .HasForeignKey(y => y.VendaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Usuario)
                .WithOne(x => x.Venda)
                .HasForeignKey<Venda>(y => y.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<VendaProduto>()
                .HasOne(vp => vp.Produto)
                .WithOne(x => x.VendaProdutos)
                .HasForeignKey<VendaProduto>(y => y.ProdutoId)
                .IsRequired();



        }
    }
}
