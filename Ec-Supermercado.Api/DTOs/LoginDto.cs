namespace Ec_Supermercado.Api.DTOs
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
