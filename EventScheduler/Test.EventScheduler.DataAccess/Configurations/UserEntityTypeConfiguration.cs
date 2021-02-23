﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
