using AutoMapper;
using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs.Mappings
{
    public class MappingCategoriaProduto : Profile
    {
        public MappingCategoriaProduto()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
