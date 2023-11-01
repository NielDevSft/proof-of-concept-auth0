using Authentication.Domain.Funcionarios.FuncionarioXHabilidades.Repository;
using Authentication.Domain.Funcionarios.Habilidades.Repository;
using Authentication.Domain.Funcionarios.Repository;
using Authentication.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Common.Ioc
{
    public class InjectorRepositories
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IFuncionarioXHabilidadeRepository, FuncionarioXHabilidadeRepository>();
            services.AddScoped<IHabilidadeRepository, HabilidadeRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }
    }
}
