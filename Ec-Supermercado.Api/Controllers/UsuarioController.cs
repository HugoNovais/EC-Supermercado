using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Pagination.Extensions;
using Ec_Supermercado.Api.Pagination.Usuario;
using Ec_Supermercado.Api.Services.UsuarioService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ec_Supermercado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<UsuarioDTO>>>Get()
        {
            var usuariosDto = await _usuarioService.GetUsuarios();

            if (usuariosDto == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok(usuariosDto);
        }
        [HttpGet("vendas")]
        public async Task <ActionResult<IEnumerable<UsuarioDTO>>>GetVendasUsuario()
        {
            var usuarioDto = await _usuarioService.GetVendasPorUsuarios();
            return Ok(usuarioDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuarioDto = await _usuarioService.GetUsuarioById(id);
            if (usuarioDto == null)
            {
                return NotFound("Usuario não encontrado!");
            }
            return Ok(usuarioDto);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get([FromQuery] UsuarioParams usuarioParams)
        {
            var usuariosDto = await _usuarioService.GetParamsUsuario(usuarioParams.PageNumber, usuarioParams.PageSize);
            Response.AddPaginationHeader(new Models.PaginationHeader(usuariosDto.CurrentPage, usuariosDto.PageSize, usuariosDto.TotalCount, usuariosDto.TotalPages));
            return Ok(usuariosDto);
        }

        [HttpGet("pagination/nome")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get([FromQuery] UsuarioFiltroNome usuarioFiltroNome)
        {
            var usuariosDto = await _usuarioService.GetParamsNomeUsuario(usuarioFiltroNome.Nome, usuarioFiltroNome.PageNumber, usuarioFiltroNome._pageSize);
            Response.AddPaginationHeader(new Models.PaginationHeader(usuariosDto.CurrentPage, usuariosDto.PageSize, usuariosDto.TotalCount, usuariosDto.TotalPages));
            return Ok(usuariosDto);

        }


        [Authorize(Roles = "Administrador")]
        [HttpPut("inativaUsuario/{id}")]
        public async Task<ActionResult<UsuarioDTO>> Put(int id)
        {
            try
            {
                var usuarioDto = await _usuarioService.InativaUsuarioById(id);
                return Ok(usuarioDto);
            }
            catch (Exception ex)
            {

                return BadRequest($"Não foi possível inativar funcionário: {ex.Message}");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null) return BadRequest();
            
            await _usuarioService.AddUsuario(usuarioDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if(id != usuarioDto.Id) return BadRequest();

            if(usuarioDto == null) return BadRequest();

            await _usuarioService.UpdateUsuario(usuarioDto);
            return Ok(usuarioDto);
        }

        //[Authorize(Roles = "SuperAdministrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(int id)
        {
            var usuarioDto = await _usuarioService.GetUsuarioById(id);
            if(usuarioDto == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            await _usuarioService.DeleteUsuario(id);
            return Ok(usuarioDto);
        }

    }
}
