using Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aplicacao.DTOs;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BoletoController : ControllerBase
    {
        private readonly ServicoBoleto _servico;

        public BoletoController(ServicoBoleto service)
        {
            _servico = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var boletos = await _servico.ObterTodosAsync();
            return Ok(boletos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var boleto = await _servico.ObterPorIdAsync(id);
            return boleto is null ? NotFound() : Ok(boleto);
        }

        [HttpGet("banco/{bancoId}")]
        public async Task<IActionResult> ObterPorBanco(int bancoId)
        {
            var boletos = await _servico.ObterPorBancoIdAsync(bancoId);
            return Ok(boletos);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(BoletoCriacaoDto dto)
        {
            var criado = await _servico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, BoletoCriacaoDto dto)
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