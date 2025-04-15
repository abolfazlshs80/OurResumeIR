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


 
    public class UserToSkillConfiguration : IEntityTypeConfiguration<UserToSkill>
    {
        public void Configure(EntityTypeBuilder<UserToSkill> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(a => a.Skill)
                .WithMany(a => a.UserToSkill)
                .HasForeignKey(a => a.SkillId);

            builder.HasOne(a => a.SkillLevel)
                .WithMany(a => a.UserToSkill)
                .HasForeignKey(a => a.SkillLevelId);
            builder.HasOne(a => a.User)
                .WithMany(a => a.UserToSkill)
                .HasForeignKey(a => a.UserId);
            //// تنظیمات فیلد Shadow برای به‌روزرسانی تاریخ
            //builder.Property<DateTime>("UpdatedDate");
        }
    }
}
