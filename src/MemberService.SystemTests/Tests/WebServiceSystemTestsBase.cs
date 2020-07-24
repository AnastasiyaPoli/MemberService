using LightBDD.NUnit3;
using MemberService.SystemTests.Core;
using MemberService.SystemTests.Proxy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

[assembly: LightBddScope]
namespace MemberService.SystemTests.Tests
{
    public class WebServiceSystemTestsBase: FeatureFixture
    {
        protected ServiceProxy Proxy;
        private KestrelWebService _service;

        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json")
            .Build();

        [SetUp]
        public async Task SetUp()
        {
            _service = new KestrelWebService(Configuration);
            await _service.Start();

            Proxy = new ServiceProxy
            (
                _service.GetUrl()
            );
        }

        [TearDown]
        public void TearDown()
        {
            _service?.Stop();
        }
    }
}