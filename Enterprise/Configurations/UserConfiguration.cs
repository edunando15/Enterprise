﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Surname).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(u => u.Id)
                .IsUnique();
            builder.Property(u => u.Password).HasMaxLength(50)
                .IsRequired();
        }
    }
}
