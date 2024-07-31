using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.Models
{
    public class VendaProduto
    {
        [Key]
        public int VendaProdutoId { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeRetirada { get; set; }
    }
}
