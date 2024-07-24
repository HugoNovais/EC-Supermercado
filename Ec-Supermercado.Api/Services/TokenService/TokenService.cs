using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Repositories.UsuarioRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ec_Supermercado.Api.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public TokenService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> GenerateToken(Usuario usuario)
        {
            var userDataBase = await _usuarioRepository.GetByEmailSenha(usuario.Email, usuario.Senha);
            if (usuario.Email != userDataBase.Email && usuario.Senha != userDataBase.Senha) { return String.Empty; }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"] ?? string.Empty));

            var issuer = _configuration["JWT:ValidIssuer"];
            var audience = _configuration["JWT:ValidAudience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, usuario.Email),
                    
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
