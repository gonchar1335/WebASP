using WebMVCCource.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options => {
    options.Filters.Add(typeof(CustomHeaderResultFilterAttribute));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseStatusCodePages();
// app.UseStatusCodePagesWithReExecute("Home/ErrorEx?statuscode={0}");
app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapStaticAssets();



 //app.MapControllerRoute(
//    name: "search",
//    pattern: "search/{search}",
//    defaults: new { controller = "Course", action = "Search" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllers();

app.Run();
