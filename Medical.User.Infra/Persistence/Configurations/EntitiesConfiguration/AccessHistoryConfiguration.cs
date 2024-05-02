using Medical.User.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Infra.Persistence.Configurations.EntitiesConfiguration
{
    [ExcludeFromCodeCoverage]
    public sealed class AccessHistoryConfiguration : IEntityTypeConfiguration<AccessHistory>
    {
        public void Configure(EntityTypeBuilder<AccessHistory> builder)
        {
            builder.HasNoKey();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Date).IsRequired();
        }
    }
}
