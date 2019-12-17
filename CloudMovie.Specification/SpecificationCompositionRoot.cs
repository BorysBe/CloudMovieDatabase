using System;
using System.IO;
using MainService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CloudMovie.Specification
{
    public class SpecificationCompositionRoot : CompositionRoot
    {
        private readonly XunitLoggerProvider _logProvider;

        public SpecificationCompositionRoot(XunitLoggerProvider logProvider)
        {
            _logProvider = logProvider;
        }

        protected override IHostBuilder CreateWebHostBuilder(Action<IWebHostBuilder> build, IHostBuilder hostBuilder)
        {
            return hostBuilder
                .ConfigureWebHostDefaults(configure => { build(configure.UseTestServer()); });
        }

        protected override void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddProvider(_logProvider);
        }
    }
}
