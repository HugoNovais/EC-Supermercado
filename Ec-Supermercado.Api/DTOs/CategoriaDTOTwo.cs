using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.DTOs
{
    public class CategoriaDTOTwo
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

    }
}
