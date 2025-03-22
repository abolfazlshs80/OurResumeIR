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


 
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(100);

            //// تنظیمات فیلد Shadow برای به‌روزرسانی تاریخ
            //builder.Property<DateTime>("UpdatedDate");
        }
    }
}
