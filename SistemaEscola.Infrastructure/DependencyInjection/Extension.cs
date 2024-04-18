using Microsoft.Extensions.DependencyInjection;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Infrastructure.Context;
using SistemaEscola.Infrastructure.Interfaces.Contexts;
using SistemaEscola.Infrastructure.Repositories;

namespace SistemaEscola.Infrastructure.DependencyInjection
{
    public static class Extension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            return services;
        }
    }
}