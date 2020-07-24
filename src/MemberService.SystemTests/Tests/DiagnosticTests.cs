using MemberService.SystemTests.Proxy;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MemberService.SystemTests.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DiagnosticTests : WebServiceSystemTestsBase
    {
        [Test]
        public async Task Given_ServiceIsRunning_When_PingActionIsCalled_Then_ResponseStatusCodeShouldBeSucceed()
        {
            var response = await Proxy.Ping();
            response.ShouldBeSuccessful();
        }
    }
}