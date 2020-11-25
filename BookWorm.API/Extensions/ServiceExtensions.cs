using BookWorm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace BookWorm.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("Bookworm")));
        }

        public static void AddIdentityServerConfig(this IServiceCollection services, IConfiguration Configuration)
        {
//            services.AddAuthentication(
//                IdentityServerAuthenticationDefaults.AuthenticationScheme)
//                .AddIdentityServerAuthentication(options =>
//                {
//                    options.Authority = Configuration.GetSection("Identity:IdentityServerBaseUrl").Value;
//                    options.ApiName = Configuration.GetSection("Api:Name").Value;
//#if RELEASE
//                    options.RequireHttpsMetadata = true;
//#else
//                    options.RequireHttpsMetadata = false;
//#endif
//                });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {

        }
    }
}
