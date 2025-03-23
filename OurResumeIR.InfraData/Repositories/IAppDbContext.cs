using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    internal interface IAppDbContext
    {

        #region DbSet

        DbSet<User> Users { get; set; }
        DbSet<AboutMe> AboutMes { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<Documents> Documents { get; set; }
        DbSet<Experience> Experiences { get; set; }
        DbSet<ExpertiseLayer> ExpertiseLayers { get; set; }
        DbSet<MyExperiences> MyExperiences { get; set; }
        DbSet<UserExpertise> UserExpertises { get; set; }

        Task SaveChange();
        #endregion
    }
}
