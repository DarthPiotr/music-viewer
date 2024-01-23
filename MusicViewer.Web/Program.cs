using INF148187148204.MusicViewer.BLC;
using Microsoft.AspNetCore.Rewrite;

namespace INF148187148204.MusicViewer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllersWithViews();

            builder.Services.AddServerSideBlazor();

            builder.Services.AddSingleton<BLController>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapBlazorHub();
            var rewriteOptions = new RewriteOptions();
            rewriteOptions.AddRewrite("_blazor(.*)", "/_blazor$1", skipRemainingRules: true);
            app.UseRewriter(rewriteOptions);

            app.Run();
        }
    }
}