using Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aplicacao.DTOs;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly ServicoUsuario _servico;
        private readonly ServicoToken _servicoToken;

        public UsuarioController(ServicoUsuario service, ServicoToken servicoToken)
        {
            _servico = service;
            _servicoToken = servicoToken;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var usuarios = await _servico.ObterTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var usuario = await _servico.ObterPorIdAsync(id);
            return usuario is null ? NotFound() : Ok(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioCriacaoDto dto)
        {
            var criado = await _servico.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, UsuarioCriacaoDto dto)
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var resultado = await _servico.LoginAsync(dto.Login, dto.Senha, _servicoToken);
            return resultado is null ? Unauthorized("Login ou senha inválidos.") : Ok(resultado);
        }
    }
}