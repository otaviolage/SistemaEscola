using Microsoft.Extensions.DependencyInjection;
using SistemaEscola.Domain.Interfaces.Services;
using SistemaEscola.Domain.Services;

namespace SistemaEscola.Domain.DependencyInjection
{
    public static class Extension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ITurmaService, TurmaService>();

            return services;
        }
    }
}