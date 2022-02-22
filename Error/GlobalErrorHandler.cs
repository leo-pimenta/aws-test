using System.Net;

namespace aws_test.Error
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate Request;
        private readonly Serilog.ILogger Log;

        public GlobalErrorHandler(RequestDelegate request, Serilog.ILogger log)
        {
            this.Request = request;
            this.Log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Request(context);
            }
            catch (Exception e)
            {
                Log.Error($"Request error at {context.Request.Path} ({context.Request.Method}) - {e}");

                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                
                await response.WriteAsJsonAsync(new 
                { 
                    status = 500,
                    description = "An unexpected error ocurred."
                });
            }
        }
    }
}