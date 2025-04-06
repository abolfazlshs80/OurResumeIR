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
            //builder.Property(e => e.Username).IsRequired().HasMaxLength(100);


            builder.HasMany(a => a.UserExpertise)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Blog)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Documents)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);


            builder.HasMany(a => a.MyExperiences)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.AboutMe)
                .WithOne(a => a.User)
                .HasForeignKey< AboutMe>(a => a.UserId);
            //// تنظیمات فیلد Shadow برای به‌روزرسانی تاریخ
            //builder.Property<DateTime>("UpdatedDate");
        }
    }
}
