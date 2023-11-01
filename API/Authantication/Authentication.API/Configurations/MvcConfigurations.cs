using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.API.Configurations
{
    public static class MvcConfigurations
    {
        public static void AddMvcSecurity(this IServiceCollection services)
        {
            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://authentication.auth0.com/";
                options.Audience = "http://example-auth0/";
            });
        }
    }
}
