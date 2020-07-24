using MemberService.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MemberService.SystemTests.Core
{
    public class KestrelWebService
    {
        protected readonly IWebHost Server;
        protected readonly IConfiguration Configuration;

        public KestrelWebService(IConfiguration configuration)
        {
            Configuration = configuration;
            Server = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<TestStartup>()
                .ConfigureKestrel((context, options) =>
                {
                    options.Listen(IPAddress.Loopback, 5000);
                })
                .UseConfiguration(Configuration)
                .UseSetting("applicationName", "MemberService.Api")
                .Build();
        }

        public Task Start()
        {
            return Server.StartAsync();
        }

        public Task Stop()
        {
            return Server.StopAsync();
        }

        public Uri GetUrl()
        {
            var addresses = Server.ServerFeatures.Get<IServerAddressesFeature>().Addresses;
            return new Uri(addresses.First());
        }
    }
}