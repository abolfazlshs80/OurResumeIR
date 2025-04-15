
namespace OurResumeIR.MVC
{
    using Infra.Ioc;
    using Microsoft.AspNetCore.Identity;
    using OurResumeIR.Domain.Models;
    using OurResumeIR.Infra.Data.Context;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    // اضافه کردن مسیرهای سفارشی برای جست‌وجوی Partial View
                    options.ViewLocationFormats.Add("/Views/Shared/Partials/Layout/{0}.cshtml");
                });
            // 1. Configuration
            //  var connectionString = builder.Configuration.GetConnectionString("LocalMain");
            var connectionString = builder.Configuration.GetConnectionString("LocalMain");

            // 2. Register DbContext
            builder.Services.RegisterService(connectionString);

            // ثبت سرویس‌ها از IoC

            builder.Services.RegisterService(connectionString);

            // تنظیمات Identity
            builder.Services.AddIdentity<User, IdentityRole>()
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();

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
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=User}/{action=ProFile}/{id?}"
            );

   

                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapRazorPages();

            app.Run();
        }
    }
}
