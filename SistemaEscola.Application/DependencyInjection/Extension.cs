using Microsoft.Extensions.DependencyInjection;
using SistemaEscola.Application.Applications;
using SistemaEscola.Domain.Interfaces.Applications;

namespace SistemaEscola.Application.DependencyInjection
{
    public static class Extension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddScoped<IAlunoApplication, AlunoApplication>();
            services.AddScoped<ITurmaApplication, TurmaApplication>();

            return services;
        }
    }
}