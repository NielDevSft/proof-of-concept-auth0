using Microsoft.Extensions.DependencyInjection;

namespace Authentication.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
