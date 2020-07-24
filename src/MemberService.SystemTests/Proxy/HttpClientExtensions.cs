using System.Net.Http;
using System.Threading.Tasks;

namespace MemberService.SystemTests.Proxy
{
    public static class HttpClientExtensions
    {
        public static async Task<Result> GetAsResultAsync(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url).ConfigureAwait(false);

            return Result.ParseFromHttpResponse(response);
        }
    }
}