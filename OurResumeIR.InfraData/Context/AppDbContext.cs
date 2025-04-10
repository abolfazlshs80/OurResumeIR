using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Context
{
    public class AppDbContext : IdentityDbContext<User,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext)));
            base.OnModelCreating(modelBuilder);
        }

        #region DbSet

      //  public DbSet<User> Users { get; set; }
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExpertiseLayer> ExpertiseLayers { get; set; }
        public DbSet<MyExperiences> MyExperiences { get; set; }
        public DbSet<UserExpertise> UserExpertises { get; set; }


        #endregion


    }
}
