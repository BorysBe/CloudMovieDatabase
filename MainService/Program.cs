using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MainService
{
    public abstract class CompositionRoot
    {
        public IHostBuilder Initialize<TStartup>()
            where TStartup : class, IStartup
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(provider =>
                    {
                        var config = provider.GetRequiredService<IConfiguration>();
                        var connectionString = new ConnectionString();
                        config.GetSection("ConnectionString").Bind(connectionString);
                        return connectionString;
                    });
                });

            var webHostBuilder = CreateWebHostBuilder(configure =>
            {
                configure.ConfigureAppConfiguration((ctx, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                    .ConfigureLogging(ConfigureLogging)

                    .ConfigureServices(
                        GetConfigureServices()
                    )
                    .UseStartup<TStartup>();
            }, hostBuilder);
            return webHostBuilder;
        }

        protected virtual void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddConsole();
        }

        protected Action<IServiceCollection> GetConfigureServices()
        {
            return x =>
            {
            };
        }

        protected virtual IHostBuilder CreateWebHostBuilder(Action<IWebHostBuilder> build, IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureWebHostDefaults(build);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
