using AutoMapper;
using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Pagination;
using Ec_Supermercado.Api.Repositories.ProdutoRepository;

namespace Ec_Supermercado.Api.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtoEntity = await _produtoRepository.GetAll();
            return  _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<PagedList<ProdutoDTO>> GetParamsProduto(int pageNumber, int pageSize)
        {
            var produtos = await _produtoRepository.GetParamsAsync(pageNumber, pageSize);
            var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            
            return new PagedList<ProdutoDTO>(produtosDTO, pageNumber, pageSize, produtos.TotalCount);
        }

        public async Task<ProdutoDTO> GetProdutoById(int id)
        {
            var produtoEntity = await _produtoRepository.GetById(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task AddProduto(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Create(produtoEntity);
            produtoDTO.ProdutoId = produtoEntity.ProdutoId;
        }

        public async Task UpdateProduto(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Update(produtoEntity);
        }

        public async Task DeleteProduto(int id)
        {
            var produtoEntity =  _produtoRepository.GetById(id).Result;
            await _produtoRepository.Delete(produtoEntity.ProdutoId);
        }


     
    }
}
