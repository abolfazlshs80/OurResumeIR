using Microsoft.CodeAnalysis;
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
    public class DocumentCofigoration : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(256);
                

            builder.Property(d => d.ImageName)
                .IsRequired()
                .HasMaxLength(256);
               

            builder.HasOne(d => d.User)
                .WithMany(d => d.Documents);
        }
    }
}
