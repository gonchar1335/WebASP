using StudentServices.Services;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHello,Hello>();
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html;charset=utf8";
    await next();
});


app.Run(async (context) =>
    {
        var hello = context.RequestServices.GetService<IHello>();
        await context.Response.WriteAsync($"<h1> {hello!.GetHelloString()} </h1>");
    });

app.Run();
