using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace CloudMovie.Specification
{
    public class TestBase : IDisposable
    {
        public readonly IHost TestServer;
        public readonly HttpClient Client;

        public TestBase(ITestOutputHelper testOutputHelper)
        {
            var logProvider = new XunitLoggerProvider(testOutputHelper);
            var builder = new SpecificationCompositionRoot(logProvider)
                .Initialize<TestStartup>();

            TestServer = builder.Start();
            Client = TestServer.GetTestClient();
            Client.Timeout = new TimeSpan(0, 5, 0);

        }

        public void Dispose()
        {
            TestServer?.Dispose();
            Client?.Dispose();
        }
    }
}