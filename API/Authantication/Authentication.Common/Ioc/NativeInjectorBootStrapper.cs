using Authentication.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Authentication.Common.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Repositories
            InjectorRepositories.AddRepositories(services);

            //Services Bussines
            InjectorServices.AddServices(services);

            //Contexts
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<AuthenticationOrganizationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
