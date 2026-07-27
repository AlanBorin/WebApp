using AutoMapper;
using Dominio.Interface;
using Dominio.Entidade;
using Aplicacao.DTOs;

namespace Aplicacao.Servicos
{
    public class ServicoBanco
    {
        private readonly IRepositorioBanco _repositorio;
        private readonly IMapper _mapper;

        public ServicoBanco(IRepositorioBanco repository, IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }

        public async Task<BancoDto?> ObterPorIdAsync(int id)
        {
            var banco = await _repositorio.ObterPorIdAsync(id);
            return banco is null ? null : _mapper.Map<BancoDto>(banco);
        }

        public async Task<BancoDto?> ObterPorCodigoAsync(string codigo)
        {
            var banco = await _repositorio.ObterPorCodigoAsync(codigo);
            return banco is null ? null : _mapper.Map<BancoDto>(banco);
        }

        public async Task<List<BancoDto>> ObterTodosAsync()
        {
            var bancos = await _repositorio.ObterTodosAsync();
            return _mapper.Map<List<BancoDto>>(bancos);
        }

        public async Task<BancoDto> CriarAsync(BancoCriacaoDto dto)
        {
            var banco = _mapper.Map<Banco>(dto);
            await _repositorio.AdicionarAsync(banco);
            await _repositorio.SalvarAsync();
            return _mapper.Map<BancoDto>(banco);
        }

        public async Task<bool> AtualizarAsync(int id, BancoCriacaoDto dto)
        {
            var banco = await _repositorio.ObterPorIdAsync(id);
            if (banco is null) return false;

            banco.Nome = dto.Nome;
            banco.Codigo = dto.Codigo;
            banco.PercentualJuros = dto.PercentualJuros;

            _repositorio.Atualizar(banco);
            return await _repositorio.SalvarAsync();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var banco = await _repositorio.ObterPorIdAsync(id);
            if (banco is null) return false;

            _repositorio.Remover(banco);
            return await _repositorio.SalvarAsync();
        }
    }
}