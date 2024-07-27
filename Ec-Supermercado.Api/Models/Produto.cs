using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public long Estoque { get; set; }
        public bool Ativo { get; set; }
        public int CategoryId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
