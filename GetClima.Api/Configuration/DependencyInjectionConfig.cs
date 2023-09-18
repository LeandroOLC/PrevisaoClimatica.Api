using PrevisaoClimatica.Api.Data.Repository;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Models;
using PrevisaoClimatica.Api.Services;

namespace PrevisaoClimatica.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IClimaService, ClimaService>();

            services.AddScoped<IAeroportoPrevisaoRepository, AeroportoPrevisaoRepository>();
            services.AddScoped<ICidadePrevisaoRepository, CidadePrevisaoRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
        }
    }
}
