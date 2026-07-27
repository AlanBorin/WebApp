using AutoMapper;
using Dominio.Interface;
using Dominio.Entidade;
using Aplicacao.DTOs;

namespace Aplicacao.Servicos
{
    public class ServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly IMapper _mapper;

        public ServicoUsuario(IRepositorioUsuario repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto?> ObterPorIdAsync(int id)
        {
            var usuario = await _repositorio.ObterPorIdAsync(id);
            return usuario is null ? null : _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto?> ObterPorLoginAsync(string login)
        {
            var usuario = await _repositorio.ObterPorLoginAsync(login);
            return usuario is null ? null : _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<List<UsuarioDto>> ObterTodosAsync()
        {
            var usuarios = await _repositorio.ObterTodosAsync();
            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> CriarAsync(UsuarioCriacaoDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            await _repositorio.AdicionarAsync(usuario);
            await _repositorio.SalvarAsync();
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> AtualizarAsync(int id, UsuarioCriacaoDto dto)
        {
            var usuario = await _repositorio.ObterPorIdAsync(id);
            if (usuario is null) return false;

            usuario.Nome = dto.Nome;
            usuario.Login = dto.Login;
            usuario.Senha = dto.Senha;

            _repositorio.Atualizar(usuario);
            return await _repositorio.SalvarAsync();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var usuario = await _repositorio.ObterPorIdAsync(id);
            if (usuario is null) return false;

            _repositorio.Remover(usuario);
            return await _repositorio.SalvarAsync();
        }

        public async Task<LoginRespostaDto?> LoginAsync(string login, string senha, ServicoToken servicoToken)
        {
            var usuario = await _repositorio.ObterPorLoginAsync(login);
            if (usuario is null || usuario.Senha != senha) return null;

            var (token, expiraEm) = servicoToken.GerarToken(usuario);

            usuario.Token = token;
            _repositorio.Atualizar(usuario);
            await _repositorio.SalvarAsync();

            return new LoginRespostaDto { Token = token, ExpiraEm = expiraEm };
        }
    }
}