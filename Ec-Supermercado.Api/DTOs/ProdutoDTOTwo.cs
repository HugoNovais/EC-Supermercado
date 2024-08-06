using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.DTOs
{
    public class ProdutoDTOTwo
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "The Price is Required")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "The Stock is Required")]
        public long Estoque { get; set; }
        [Required(ErrorMessage = "The Category is Required")]
        public bool Ativo { get; set; }
        public int CategoryId { get; set; }
        public ICollection<VendaProdutoDTOTwo> VendaProdutos { get; set; } = new List<VendaProdutoDTOTwo>();
    }
}
