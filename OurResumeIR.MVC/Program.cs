﻿
namespace OurResumeIR.MVC
{
    using Infra.Ioc;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
          //  builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    // اضافه کردن مسیرهای سفارشی برای جست‌وجوی Partial View
                    options.ViewLocationFormats.Add("/Views/Shared/Partials/Layout/{0}.cshtml");
                });
            // 1. Configuration
            //  var connectionString = builder.Configuration.GetConnectionString("LocalMain");
            var connectionString = builder.Configuration.GetConnectionString("LocalMaiSqllite");

            // 2. Register DbContext
            builder.Services.RegisterService(connectionString);

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
