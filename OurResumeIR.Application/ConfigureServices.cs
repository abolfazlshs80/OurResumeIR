using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;

namespace OurResumeIR.Application
{
 

   


    public static class ApplicationServiceRegistration
    {
        
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            #region Service
            services.AddScoped<IFileUploaderService, LocalUploaderService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IHistoryService, HistoryService>();

            services.AddScoped<IBlogService, BlogService>();


            services.AddScoped<IDocumentService, DocumentService>();

            #endregion

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
         
        }
    }
}


    


        
   


