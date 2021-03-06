﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountOwner.DataAccessLayer.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.Property(s => s.Id)
                .HasColumnName("OwnerId");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.DateOfBirth)
                .IsRequired(true);

            builder.Property(s => s.Address)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
