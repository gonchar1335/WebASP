using WebMiddleware;

var builder = WebApplication.CreateBuilder(args);


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
    await next();
});

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get)
        await context.Response.WriteAsync("Start First Middleware<br>");

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
