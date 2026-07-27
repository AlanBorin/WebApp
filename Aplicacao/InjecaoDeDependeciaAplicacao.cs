using Aplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao
{
    public static class InjecaoDeDependeciaAplicacao
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ServicoBanco>();
            services.AddScoped<ServicoBoleto>();
            services.AddScoped<ServicoUsuario>();
            services.AddScoped<ServicoToken>();
            services.AddAutoMapper(typeof(InjecaoDeDependeciaAplicacao));

            return services;
        }
    }
}
