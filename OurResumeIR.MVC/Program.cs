
using OurResumeIR.Application;
using OurResumeIR.Infrastructure;

namespace OurResumeIR.MVC
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks();
            // Add services to the container.
            builder.Services
                .AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/Views/Shared/Partials/Layout/{0}.cshtml");
                });
      
        
            builder.Services.RegisterInfrastructureServices(builder.Configuration);
            builder.Services.RegisterApplicationServices();
       

       
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(name: "areas",
                pattern: "{area:exists}/{controller=User}/{action=ProFile}/{id?}"
            );
            app.MapControllerRoute(name: "default",
            pattern: "{controller=Home}/{action=SkillIndex}/{id?}");

            //app.MapRazorPages();
            app.UseHealthChecks("/Health");
            app.Run();
        }
    }
}
