﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
           builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(250);


            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(3000);


            builder.Property(b => b.ImageName)
                .IsRequired();


            builder.Property(b => b.Text)
                .IsRequired()
                .HasMaxLength(4000);
               
            builder.HasOne(b => b.User)
                .WithMany(b => b.Blog);
        }
    }
}
