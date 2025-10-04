using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using System.Text;
using WebEFC;


namespace WebEFC 
{
    public class Program
    {
        internal static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMemoryCache();
            builder.Services.AddOutputCache();

            builder.Services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            builder.Services.TryAddSingleton<ObjectPool<StringBuilder>>(serviceProvider => 
                {
                    var provider = serviceProvider.GetService<ObjectPoolProvider>();
                    var policy = new StringBuilderPooledObjectPolicy();
                    return provider!.Create(policy);
                });

            //builder.Services.AddDistributedMemoryCache(); // нужны библиотеки  EntityFramework NCache
            builder.Services.AddSqlServer<ApplicationContext>(
                config.GetConnectionString("DefaultConnection"));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseOutputCache();
            app.UseRouting();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();
        }
    }
}




