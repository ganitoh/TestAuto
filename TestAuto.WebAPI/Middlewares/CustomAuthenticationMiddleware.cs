using System.Net;

namespace TestAuto.WebAPI.Middlewares
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            var path = context.Request.Path.ToString();

            if (path.Contains("admin"))
            {
                var token = path.Split('/')[4];

                if (IsCheckToken(token, configuration["AdminToken"]!))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "Unauthorized" });
                }
            }
            else
                await _next(context);
        }

        private bool IsCheckToken(string token, string trueToken)
        {
            if (token is null)
                return false;
            else if (token != trueToken)
                return false;
            else 
                return true;
        }
    }
}
