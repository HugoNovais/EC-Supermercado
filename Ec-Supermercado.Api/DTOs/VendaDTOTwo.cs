using Ec_Supermercado.Api.Enums;
using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.DTOs
{
    public class VendaDTOTwo
    {
        public int VendaId { get; set; }
        //public ICollection<VendaProduto>? VendaProdutos { get; set; }
        [Required(ErrorMessage = "Usuario is Required")]
        public int UsuarioId { get; set; }
        //public Usuario? Usuario { get; set; }
        [Required(ErrorMessage = "Venda is Required")]
        public double VendaTotal { get; set; }
        [Required(ErrorMessage = "Pagamento is Required")]
        public PagamentoEnum Pagamento { get; set; }
        public string? Detalhes { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
