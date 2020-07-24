using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberService.SystemTests.Proxy
{
    public class ServiceProxy
    {
        protected const int RequestTimeoutMilliseconds = 1000000000;
        private readonly HttpClient _client;

        public ServiceProxy(Uri serviceUrl)
        {
            var handler = new HttpClientHandler();

            _client = new HttpClient(handler)
            {
                BaseAddress = serviceUrl,
                Timeout = TimeSpan.FromMilliseconds(RequestTimeoutMilliseconds)
            };
        }

        public Task<Result> Ping()
        {
            return _client.GetAsResultAsync("ping");
        }
    }
}