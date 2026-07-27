using Dominio.Interface;
using Infraestrutura.Context;
using Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Infraestrutura
{
    public static class InjecaoDeDependecia
    {
        public static IServiceCollection AddInfrastructure(
             this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                       .UseSnakeCaseNamingConvention());

            services.AddScoped<IRepositorioBanco, RepositorioBanco>();
            services.AddScoped<IRepositorioBoleto, RepositorioBoleto>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            return services;
        }
    }
}
