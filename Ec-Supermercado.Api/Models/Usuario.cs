using Ec_Supermercado.Api.Enums;
using System.Text.Json.Serialization;

namespace Ec_Supermercado.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha {  get; set; }
        public bool Ativo {  get; set; } = true;
        public PerfilEnum Perfil { get; set; }
        
        public ICollection<Venda>? Vendas { get; set; } 
    }
}
