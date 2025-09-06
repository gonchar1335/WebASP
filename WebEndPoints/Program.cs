using System.Collections;
using WebEndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();

app.MapGet("/api/courses", async context =>
        await context.Response.WriteAsJsonAsync(Course.All));
app.MapGet("/api/courses/{id:int}", async (HttpContext context, int id) =>
{
    Course c = Course.All.Where(c => c.Id == id).SingleOrDefault()!;
    if (c != null)
    {
        await context.Response.WriteAsJsonAsync(c);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
});

app.MapGet("/api/courses/{search}", async (HttpContext context, string search) =>
{
    IEnumerable<Course> c = Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
    await context.Response.WriteAsJsonAsync(c);

});


app.MapDelete("api/course/{id:int}", async ( HttpContext context, int id) =>
    {
        Course c = Course.All.Where(c => c.Id == id).SingleOrDefault()!;
        if (c != null)
        {
            Course.All.Remove(c);
        }
        else
            context.Response.StatusCode = StatusCodes.Status404NotFound;
    });

app.MapPost("/api/course", async (HttpContext context, Course c) => {
    if (c.Id == 0) c.Id = Course.All.Select(c => c.Id).Max() + 1;
    Course.All.Add(c);
    await context.Response.WriteAsJsonAsync(c);
});


app.Run();
