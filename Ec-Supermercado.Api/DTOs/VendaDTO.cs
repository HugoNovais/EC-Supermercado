using Ec_Supermercado.Api.Enums;
using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ec_Supermercado.Api.DTOs
{
    public class VendaDTO
    {
        public int VendaId { get; set; }
        public ICollection<VendaProdutoDTO>? VendaProdutos { get; set; } 
        [Required(ErrorMessage = "Usuario is Required")]
        public int UsuarioId { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        [Required(ErrorMessage = "Venda is Required")]
        public decimal VendaTotal { get; set; }
        [Required(ErrorMessage = "Pagamento is Required")]
        public PagamentoEnum Pagamento { get; set; }
        public string? Detalhes { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
