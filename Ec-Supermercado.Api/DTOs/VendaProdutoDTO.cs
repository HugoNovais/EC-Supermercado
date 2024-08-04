using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs
{
    public class VendaProdutoDTO
    {
        public int VendaProdutoId { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeRetirada { get; set; }
    }
}
