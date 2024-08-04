using AutoMapper;
using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Repositories.VendaProdutoRepository;

namespace Ec_Supermercado.Api.Services.VendaProdutoService
{
    public class VendaProdutoService : IVendaProdutoService
    {

        private readonly IVendaProdutoRepository _repository;
        private readonly IMapper _mapper;

        public VendaProdutoService(IVendaProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendaProdutoDTO>> GetVendaProdutos()
        {
            var vendaProdutoEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<VendaProdutoDTO>>(vendaProdutoEntity);
        }

        public async Task<VendaProdutoDTO> GetVendaProduto(int id)
        {
            var vendaProdutoEntity = await _repository.GetById(id);
            return _mapper.Map<VendaProdutoDTO>(vendaProdutoEntity);
        }

        public async Task AddVendaProduto(VendaProdutoDTO vendaProduto)
        {
            var vendaProdutoEntity = _mapper.Map<VendaProduto>(vendaProduto);
            await _repository.Create(vendaProdutoEntity);
            vendaProduto.VendaProdutoId = vendaProdutoEntity.VendaProdutoId;
        }


        public async Task UpdateVendaProduto(VendaProdutoDTO vendaProduto)
        {
            var vendaProdutoEntity = _mapper.Map<VendaProduto>(vendaProduto);
            await _repository.Update(vendaProdutoEntity);
        }

        public async Task DeleteVendaProduto(int id)
        {
            var vendaProdutoEntity =  _repository.GetById(id).Result;
            await _repository.DeleteById(vendaProdutoEntity.VendaId);
        }

 
    }
}
