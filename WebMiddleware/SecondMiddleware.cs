namespace WebMiddleware
{
    public class SecondMiddleware
    { 
        private RequestDelegate _next;
        public SecondMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            await context.Response.WriteAsync($"Status code = {context.Response.StatusCode}<br>");
            await _next(context);
        }
    }
}
