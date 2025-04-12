using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Infra.Data.Context;
using OurResumeIR.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddScoped<IAboutMeRepository, AboutRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<IDocumentsRepository, DocumentRepository>();
            services.AddScoped<IExpertiseLayerRepository, ExpertiseLayerRepository>();
            services.AddScoped<IMyExperiencesRepository, MyExperienceRepository >();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserExpertiseRepository, UserExpertiseRepository >();
            services.AddScoped<IUserService, UserService>();


        }
    }
}
