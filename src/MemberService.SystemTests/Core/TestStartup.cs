using MemberService.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MemberService.SystemTests.Core
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, IHostingEnvironment environment) 
            : base(configuration, environment)
        {
        }

        //there will be settings for test startup, overridden methods, etc.
    }
}