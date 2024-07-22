using AutoMapper;
using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs.Mappings
{
    public class MappingUsuario : Profile
    {
        public MappingUsuario()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
