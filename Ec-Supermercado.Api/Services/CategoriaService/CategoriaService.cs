using AutoMapper;
using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Repositories.CategoriaRepository;

namespace Ec_Supermercado.Api.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTOTwo>> GetCategorias()
        {
            var categoriaEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDTOTwo>>(categoriaEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetProdutosPorCategoria()
        {
            var categoriaEntity = await _repository.GetCategoriasProdutos();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriaEntity);
        }

        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            var categoriaEntity = await _repository.GetById(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task AddCategoria(CategoriaDTOTwo categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _repository.Create(categoriaEntity);
            categoriaDto.CategoryId = categoriaEntity.CategoryId;
        }

        public async Task UpdateCategoria(CategoriaDTOTwo categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _repository.Update(categoriaEntity);
        }

        public async Task DeleteCategoria(int id)
        {
            var categoriaEntity =  _repository.GetById(id).Result;
            await _repository.Delete(categoriaEntity.CategoryId);
           
        }


    }
}
