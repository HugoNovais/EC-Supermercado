using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.Models
{
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        public ICollection<VendaProduto> VendaProdutos { get; set; } = new List<VendaProduto>();

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
