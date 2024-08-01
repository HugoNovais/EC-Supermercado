using AutoMapper;
using Ec_Supermercado.Api.Models;

namespace Ec_Supermercado.Api.DTOs.Mappings
{
    public class MappingVenda : Profile
    {
        public MappingVenda() 
        {
            CreateMap<Venda, VendaDTO>().ReverseMap();
        }
    }
}
