﻿using Medical.User.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.User.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired();

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.UrlProfile);

            builder.Property(x => x.Role).IsRequired();

            builder.Property(x => x.Email).IsRequired();
        }
    }
}
