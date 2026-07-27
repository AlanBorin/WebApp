using Aplicacao.DTOs;
using AutoMapper;
using Dominio.Entidade;

namespace Aplicacao.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Banco, BancoDto>();
            CreateMap<BancoCriacaoDto, Banco>();

            CreateMap<Boleto, BoletoDto>();
            CreateMap<BoletoCriacaoDto, Boleto>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCriacaoDto, Usuario>();
        }
    }
}