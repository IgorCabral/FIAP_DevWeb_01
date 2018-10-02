using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap01.Middlewares
{
    public class LogMiddleware
    {
        private RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableRewind();
            var request = await FormatRequest(context.Request);
            
            var log = new LoggerConfiguration()
            .WriteTo.Logentries("5788034d-637d-44a7-91e2-e3ac1d591640")
            .CreateLogger();
            log.Information($"request {request}");

            context.Request.Body.Position = 0;

            await _next(context);

            //TODO: Just do it 
            #region Exemplo
            //var stopWatch = new Stopwatch();
            //stopWatch.Start();
            //await _next(context);
            //stopWatch.Stop();
            //Console.WriteLine($"Demorou {stopWatch.Elapsed.Milliseconds} ms");
            #endregion
        }

        public static async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query, requestBody = bodyAsText };

            return JsonConvert.SerializeObject(messageObjToLog);
        }
    }
    
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuLogoPreza(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
