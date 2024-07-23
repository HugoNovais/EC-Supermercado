using AutoMapper;
using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs.Mappings
{
    public class MappingCategoria : Profile
    {
        public MappingCategoria()
        {
            CreateMap<Categoria, CategoriaDTOTwo>().ReverseMap();
        }
    }
}
