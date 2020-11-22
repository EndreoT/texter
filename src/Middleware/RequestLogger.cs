using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Texter.Middleware
{
    /// <summary>
    /// Logs information about each request
    /// </summary>
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            DateTime now = DateTime.Now;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            HttpRequest request = httpContext.Request;
            string method = request.Method;
            string path = request.Path;

            httpContext.Response.OnStarting(() => {

                watch.Stop();
                long reqResTotalTime = watch.ElapsedMilliseconds;
                _logger.LogInformation(string.Format("{0} {1} {2} {3} ms", now, method, path, reqResTotalTime));
                return Task.CompletedTask;
            });

            await _next(httpContext);
        }
    }
}
