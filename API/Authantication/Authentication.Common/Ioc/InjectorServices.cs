using Authentication.Domain.Funcionarios.Service;
using Authentication.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Common.Ioc
{
    public class InjectorServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IFuncionarioService, FuncionarioService>();
        }
    }
}
