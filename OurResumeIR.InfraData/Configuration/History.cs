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
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(256);
            

            builder.HasOne(m => m.User)
                .WithMany(m => m.History);
        }
    }
}
