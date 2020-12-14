using BookWorm.API.Unity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Unity.Microsoft.DependencyInjection;

namespace BookWorm.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.UseUnityServiceProvider(UnityConfig.Container)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
