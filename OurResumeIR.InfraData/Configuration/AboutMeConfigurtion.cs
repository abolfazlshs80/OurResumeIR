using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Configuration
{
    public class AboutMeConfigurtion : IEntityTypeConfiguration<AboutMe>
    {
        public void Configure(EntityTypeBuilder<AboutMe> builder)
        {
           builder.HasKey(a => a.Id);

            builder.Property(a => a.Description)
                .HasColumnType("String")
                .IsRequired()
                .HasMaxLength(1500);

            builder.HasOne(a => a.User)
                .WithOne(a => a.AboutMe);
             
        }
    }
}
