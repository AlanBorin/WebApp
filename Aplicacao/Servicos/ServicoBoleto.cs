using AutoMapper;
using Dominio.Interface;
using Dominio.Entidade;
using Aplicacao.DTOs;

namespace Aplicacao.Servicos
{
    public class ServicoBoleto
    {
        private readonly IRepositorioBoleto _repositorio;
        private readonly IRepositorioBanco _repositorioBanco;
        private readonly IMapper _mapper;

        public ServicoBoleto(IRepositorioBoleto repository, IRepositorioBanco repositorioBanco, IMapper mapper)
        {
            _repositorio = repository;
            _repositorioBanco = repositorioBanco;
            _mapper = mapper;
        }

        public async Task<BoletoDto?> ObterPorIdAsync(int id)
        {
            var boleto = await _repositorio.ObterPorIdAsync(id);
            if (boleto is null) return null;

            var dto = _mapper.Map<BoletoDto>(boleto);

            dto.Vencido = boleto.DataVencimento.Date < DateTime.Now.Date;

            if (dto.Vencido)
            {
                var banco = await _repositorioBanco.ObterPorIdAsync(boleto.BancoId);
                var percentualJuros = banco?.PercentualJuros ?? 0;
                dto.ValorComJuros = boleto.Valor + (boleto.Valor * percentualJuros / 100);
            }
            else
            {
                dto.ValorComJuros = boleto.Valor;
            }

            return dto;
        }

        public async Task<List<BoletoDto>> ObterTodosAsync()
        {
            var boletos = await _repositorio.ObterTodosAsync();
            return _mapper.Map<List<BoletoDto>>(boletos);
        }

        public async Task<List<BoletoDto>> ObterPorBancoIdAsync(int bancoId)
        {
            var boletos = await _repositorio.ObterPorBancoIdAsync(bancoId);
            return _mapper.Map<List<BoletoDto>>(boletos);
        }

        public async Task<BoletoDto> CriarAsync(BoletoCriacaoDto dto)
        {
            var boleto = _mapper.Map<Boleto>(dto);
            await _repositorio.AdicionarAsync(boleto);
            await _repositorio.SalvarAsync();
            return _mapper.Map<BoletoDto>(boleto);
        }

        public async Task<bool> AtualizarAsync(int id, BoletoCriacaoDto dto)
        {
            var boleto = await _repositorio.ObterPorIdAsync(id);
            if (boleto is null) return false;

            boleto.NomePagador = dto.NomePagador;
            boleto.CPFCNPJPagador = dto.CPFCNPJPagador;
            boleto.NomeBeneficiario = dto.NomeBeneficiario;
            boleto.CPFCNPJBeneficiario = dto.CPFCNPJBeneficiario;
            boleto.Valor = dto.Valor;
            boleto.DataVencimento = dto.DataVencimento;
            boleto.Observacao = dto.Observacao;
            boleto.BancoId = dto.BancoId;

            _repositorio.Atualizar(boleto);
            return await _repositorio.SalvarAsync();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var boleto = await _repositorio.ObterPorIdAsync(id);
            if (boleto is null) return false;

            _repositorio.Remover(boleto);
            return await _repositorio.SalvarAsync();
        }
    }
}