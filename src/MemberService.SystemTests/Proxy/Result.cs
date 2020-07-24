using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;

namespace MemberService.SystemTests.Proxy
{
    public class Result
    {
        public static Result ParseFromHttpResponse(HttpResponseMessage httpResponse)
        {
            return new Result(httpResponse.StatusCode);
        }

        protected Result(HttpStatusCode statusCode)
        {
            HttpStatusCode = statusCode;
        }

        public bool Successful => HttpStatusCode.IsSuccessful();

        public HttpStatusCode HttpStatusCode { get; }
    }

    public class Result<T> : Result
    {
        public static implicit operator T(Result<T> result)
        {
            result.ShouldBeSuccessful();
            if (result.HttpStatusCode == HttpStatusCode.NoContent)
            {
                throw new InvalidOperationException("Trying to access Value of result with NoContent status code");
            }

            return result.Value;
        }
        protected Result(HttpStatusCode statusCode, T value)
            : base(statusCode)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public static class ResultExtensions
    {
        public static void ShouldBeSuccessful(this Result result)
        {
            result.Successful.Should().BeTrue("successful operation should have result.Success == true");
        }
    }

    public static class HttpStatusCodeExtensions
    {
        public static bool IsSuccessful(this HttpStatusCode statusCode)
        {
            return (int)statusCode >= 200 && (int)statusCode < 300;
        }
    }
}