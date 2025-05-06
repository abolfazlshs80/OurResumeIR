using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using OurResumeIR.Infra.Data.Repositories;

namespace OurResumeIR.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LocalMain")));
        #endregion


        #region Repository
        services.AddScoped<IAboutMeRepository, AboutRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IDocumentsRepository, DocumentRepository>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
        services.AddScoped<IUserToSkillRepository, UserToSkillRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IContactUsRepository, ContactUsRepository>();
        services.AddScoped<IMySkillsRepository, MySkillsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion

        #region Identity

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        #endregion


        return services;
    }

}