using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Infra.Data.Configuration
{


 
    public class ExpertiseLayerConfiguration : IEntityTypeConfiguration<ExpertiseLayer>
    {
        public void Configure(EntityTypeBuilder<ExpertiseLayer> builder)
        {
            builder.HasKey(e => e.Id);
           builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
           builder.HasMany(a => a.Experience)
               .WithOne(a => a.ExpertiseLayer)
               .HasForeignKey(a => a.ExpertiseLayerId);
            //// تنظیمات فیلد Shadow برای به‌روزرسانی تاریخ
            //builder.Property<DateTime>("UpdatedDate");
        }
    }
}
