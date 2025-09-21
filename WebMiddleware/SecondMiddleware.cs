using WebMiddleware.Services;

namespace WebMiddleware
{
    public class SecondMiddleware
    { 
        private RequestDelegate _next;
        //private ICounter _counter;
        public SecondMiddleware(RequestDelegate next /*ICounter counter*/ ) // только Singleton || Transient
        {
            _next = next;
            //this._counter = counter;
        }

        public async Task Invoke(HttpContext context, ICounter counter) // Scoped 
        {
            //var counterSrv = context.RequestServices.GetRequiredService<ICounter>();
           
            await context.Response.WriteAsync($"Status code = {context.Response.StatusCode}<br>");
            await context.Response.WriteAsync($"counter  SRV= {counter.Get()}<br>");
            await _next(context);
        }
    }
}
