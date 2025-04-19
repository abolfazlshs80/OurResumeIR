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
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillLevel> SkillLevel { get; set; }
        public DbSet<UserToSkill> UserToSkill { get; set; }
        public DbSet<History> History { get; set; }



        #endregion


    }
}
