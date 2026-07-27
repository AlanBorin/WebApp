using Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aplicacao.DTOs;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BancoController : ControllerBase
    {
        private readonly ServicoBanco _servico;

        public BancoController(ServicoBanco service)
        {
            _servico = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var bancos = await _servico.ObterTodosAsync();
            return Ok(bancos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var banco = await _servico.ObterPorIdAsync(id);
            return banco is null ? NotFound() : Ok(banco);
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            var banco = await _servico.ObterPorCodigoAsync(codigo);
            return banco is null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(BancoCriacaoDto dto)
        {
            var criado = await _servico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, BancoCriacaoDto dto)
        {
            var atualizado = await _servico.AtualizarAsync(id, dto);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var removido = await _servico.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}