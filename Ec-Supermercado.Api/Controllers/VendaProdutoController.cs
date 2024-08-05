using Ec_Supermercado.Api.DTOs;
using Ec_Supermercado.Api.Services.VendaProdutoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ec_Supermercado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaProdutoController : ControllerBase
    {
        private readonly IVendaProdutoService _vendaProdutoService;

        public VendaProdutoController(IVendaProdutoService vendaProdutoService)
        {
            _vendaProdutoService = vendaProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaProdutoDTOTwo>>> Get()
        {
            var vendaProdutoDto = await _vendaProdutoService.GetVendaProdutos();
            if (vendaProdutoDto == null) return NotFound("Não possível localizar Produtos da venda");
            return Ok(vendaProdutoDto);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaProdutoDTO>> Get(int id)
        {
            var vendaProdutoDto = await _vendaProdutoService.GetVendaProduto(id);
            if (vendaProdutoDto == null) return NotFound("Não possível localizar Produto da venda");
            return Ok(vendaProdutoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(VendaProdutoDTOTwo vendaProdutoDTOTwo)
        {
            if (vendaProdutoDTOTwo == null) return BadRequest("Preencha todos os campoos");
            await _vendaProdutoService.AddVendaProduto(vendaProdutoDTOTwo);
            return Ok(vendaProdutoDTOTwo);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] VendaProdutoDTO vendaProdutoDTO)
        {
            if (id != vendaProdutoDTO.VendaId) return BadRequest();
            if (vendaProdutoDTO == null) return BadRequest();
            await _vendaProdutoService.UpdateVendaProduto(vendaProdutoDTO);
            return Ok(vendaProdutoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VendaProdutoDTO>> Delete(int id)
        {
            var vendaProdutoDto = await _vendaProdutoService.GetVendaProduto(id);
            if (vendaProdutoDto == null) return NotFound("Não foi possível localizar Venda");
            await _vendaProdutoService.DeleteVendaProduto(id);
            return Ok(vendaProdutoDto);

        }
    }
}
