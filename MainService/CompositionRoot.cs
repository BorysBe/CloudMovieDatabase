using System;
using System.IO;
using MainService.Contracts;
using MainService.Factory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MainService
{
    public abstract class CompositionRoot
    {
        public IHostBuilder Initialize<TStartup, TActorResponseFactory, TMovieResponseFactory>()
            where TStartup : class, IStartup
            where TActorResponseFactory : class, IActorResponseFactory
            where TMovieResponseFactory : class, IMovieResponseFactory

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
                        GetConfigureServices<TActorResponseFactory, TMovieResponseFactory>()
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

        private Action<IServiceCollection> GetConfigureServices<TActorResponseFactory, TMovieResponseFactory>()
            where TActorResponseFactory : class, IActorResponseFactory
            where TMovieResponseFactory : class, IMovieResponseFactory
        {
            return x =>
            {
                x.AddTransient<IActorResponseFactory, TActorResponseFactory>();
                x.AddTransient<IMovieResponseFactory, TMovieResponseFactory>();
            };
        }

        protected virtual IHostBuilder CreateWebHostBuilder(Action<IWebHostBuilder> build, IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureWebHostDefaults(build);
        }
    }
}