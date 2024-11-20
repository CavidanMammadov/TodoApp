using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");
            app.MapControllerRoute("default", "{controller=Todo}/{action=Index}/{Id?}");

            app.Run();
        }
    }
}
