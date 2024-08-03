using Ec_Supermercado.Api.Enums;
using Ec_Supermercado.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Ec_Supermercado.Api.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "The E-mail is Required")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password is Required")]
        public string Senha { get; set; }
        public bool Ativo {  get; set; }
        public PerfilEnum Perfil { get; set; }
        public ICollection<VendaDTO>? Vendas { get; set; } 
    }
}
