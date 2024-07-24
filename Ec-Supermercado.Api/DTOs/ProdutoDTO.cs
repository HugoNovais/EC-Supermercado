using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ec_Supermercado.Api.DTOs
{
    public class ProdutoDTO
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
        public int CategoryId { get; set; }
        //[JsonIgnore]
        //public Categoria? Categoria { get; set; }
    }
}
