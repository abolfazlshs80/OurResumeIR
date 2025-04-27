using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OurResumeIR.Application;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Infra.Data.Context;
using OurResumeIR.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterService(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //  options.UseSqlServer(connectionString));


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            #region Repository
            services.AddScoped<IAboutMeRepository, AboutRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IDocumentsRepository, DocumentRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
            services.AddScoped<IUserToSkillRepository, UserToSkillRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();


            #endregion
            services.AddScoped<IMySkillsRepository, MySkillsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileUploaderService, LocalUploaderService>();





            #region Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IDocumentService, DocumentService>();
            #endregion
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));

        }
    }
}
