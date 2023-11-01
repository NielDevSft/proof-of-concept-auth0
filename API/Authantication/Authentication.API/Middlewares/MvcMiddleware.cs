using Microsoft.AspNetCore.Builder;

namespace Authentication.API.Middlewares
{
    public static class MvcMiddleware
    {
        public static void UseMvcSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
