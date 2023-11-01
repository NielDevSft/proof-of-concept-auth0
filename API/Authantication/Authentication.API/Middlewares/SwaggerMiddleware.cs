using Microsoft.AspNetCore.Builder;

namespace Authentication.API.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static void UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api";
            });
        }
    }
}
