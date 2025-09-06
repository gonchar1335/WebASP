var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        await next();   
    }
);

app.Map("/time", app2 =>
{
    app2.Use(async (context, next) =>
    {
        await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        await next();
    });
});

app.Map("/date", app2 =>
{
    app2.Use(async (context, next) =>
    {
        await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
        await next();
    });
});

app.MapWhen(context => context.Request.Path == "/", app2 =>
{
    app2.Run(async (context) =>
    {
        await context.Response.WriteAsync("<h1>Hello Main Page</h1>");
    });
});

app.Run(async context =>
{
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    await context.Response.WriteAsync("Resource not found");
});

app.Run();
