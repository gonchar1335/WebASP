using WebMiddleware;
using WebMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICounter, CounterImpl>();

var app = builder.Build();


app.Map("/test", (app2) =>
{
    app2.Run(async context =>
    {
        await context.Response.WriteAsync("Test content");
    });
});


app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html";
    var counter = context.RequestServices.GetRequiredService<ICounter>();
    counter.Increment();
    await next();
});

app.Use(async (context, next) =>
{

    if (context.Request.Method == HttpMethods.Get)
    {
        //var counterSrv = app.Services.GetRequiredService<ICounter>(); // singleton or Transient
        var counter = context.RequestServices.GetRequiredService<ICounter>(); // scoped
        counter.Increment();
        await context.Response.WriteAsync("Start First Middleware<br>");
    }
        await next();
    await context.Response.WriteAsync("End First MiddleWare<br>");
});



app.UseMiddleware<SecondMiddleware>();

app.Run(async context => {
    await context.Response.WriteAsync("Hello from Run(....)");
});

app.MapGet("/", () => "Hello World!");
app.MapStaticAssets();

app.Run();
