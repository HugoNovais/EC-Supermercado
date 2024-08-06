using AutoMapper;
using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Repositories.VendaRepository;

namespace Ec_Supermercado.Api.Services.VendaService
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendaDTOTwo>> GetVendas()
        {
            var vendaEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<VendaDTOTwo>>(vendaEntity);
        }

        public async Task<IEnumerable<VendaDTO>> GetVendasPorVendaProduto()
        {
            var vendaEntity = await _repository.GetVendaProduto();
            return _mapper.Map<IEnumerable<VendaDTO>>(vendaEntity);
        }

        public async Task<VendaDTO> GetVendasById(int id)
        {
            var vendaEntity = await _repository.GetById(id);
            return _mapper.Map<VendaDTO>(vendaEntity);
        }

        public async Task AddVenda(VendaDTOTwo vendaDTO)
        {
            var vendaEntity = _mapper.Map<Venda>(vendaDTO);
            await _repository.Create(vendaEntity);
            vendaDTO.VendaId = vendaEntity.VendaId;
        }

        public async Task Update(VendaDTO vendaDTO)
        {
            var vendaEntity = _mapper.Map<Venda>(vendaDTO);
            await _repository.Update(vendaEntity);
        }

        public async Task Delete(int id)
        {
            var vendaEntity = _repository.GetById(id).Result;
            await _repository.Delete(vendaEntity.VendaId);


        }
    }
}
