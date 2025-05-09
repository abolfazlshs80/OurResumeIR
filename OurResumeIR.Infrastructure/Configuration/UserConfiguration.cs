﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Infra.Data.Configuration
{



    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var userId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<User>();
            builder.HasKey(e => e.Id);
            //builder.Property(e => e.Username).IsRequired().HasMaxLength(100);


            builder.HasMany(a => a.History)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Blog)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Documents)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);


            builder.HasMany(a => a.UserToSkill)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.AboutMe)
                .WithOne(a => a.User)
                .HasForeignKey<AboutMe>(a => a.UserId);

    

            var adminUser = new User
            {
                Id = userId,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                FullName = "Admin User",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");
            builder.HasData(adminUser);
            //// تنظیمات فیلد Shadow برای به‌روزرسانی تاریخ
            //builder.Property<DateTime>("UpdatedDate");
        }
    }
}
