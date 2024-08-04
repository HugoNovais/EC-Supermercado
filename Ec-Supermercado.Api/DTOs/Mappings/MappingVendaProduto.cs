using AutoMapper;
using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs.Mappings
{
    public class MappingVendaProduto : Profile
    {
        public MappingVendaProduto()
        {
            CreateMap<VendaProduto, VendaProdutoDTO>().ReverseMap();
            CreateMap<VendaProduto, VendaProdutoDTOTwo>().ReverseMap();
        }
    }
}
