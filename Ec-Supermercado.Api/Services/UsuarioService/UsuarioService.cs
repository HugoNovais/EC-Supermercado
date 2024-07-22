using AutoMapper;
using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Models;
using Ec_Supermercado.Api.Repositories.UsuarioRepository;

namespace Ec_Supermercado.Api.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            var usuariosEntity = await _usuarioRepository.GetAll();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuariosEntity);
        }

        public async Task<UsuarioDTO> GetUsuarioById(int id)
        {
            var usuariosEntity = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioDTO>(usuariosEntity);
        }


        public async Task AddUsuario(UsuarioDTO usuarioDto)
        {
            var usuariosEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.Create(usuariosEntity);
            usuarioDto.Id = usuariosEntity.Id;
        }

        public async Task UpdateUsuario(UsuarioDTO usuarioDto)
        {
            var usuariosEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.Update(usuariosEntity);
        }

        public async Task DeleteUsuario(int id)
        {
            var usuariosEntity = _usuarioRepository.GetById(id).Result;
            await _usuarioRepository.Delete(usuariosEntity.Id);
        }



    }
}
