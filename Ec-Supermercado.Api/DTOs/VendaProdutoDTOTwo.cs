using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.DTOs
{
    public class VendaProdutoDTOTwo
    {
        public int VendaProdutoId { get; set; }
        [Required(ErrorMessage = "VendaId is Required")]
        public int VendaId { get; set; }
        //public Venda Venda { get; set; }
        [Required(ErrorMessage = "Produto is Required")]
        public int ProdutoId { get; set; }
        //public Produto Produto { get; set; }
        [Required(ErrorMessage = "QuantidadeRetirada is Required")]
        public int QuantidadeRetirada { get; set; }
    }
}
