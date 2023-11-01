using Authentication.Common.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
