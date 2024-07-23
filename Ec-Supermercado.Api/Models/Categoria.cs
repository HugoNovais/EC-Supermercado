using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.Models
{
    public class Categoria
    {
        [Key]
        public int CategoryId { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
    }
}
