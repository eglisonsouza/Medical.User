using Medical.User.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.User.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class AccessHistoryConfiguration : IEntityTypeConfiguration<AccessHistory>
    {
        public void Configure(EntityTypeBuilder<AccessHistory> builder)
        {
            builder.HasNoKey();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Date).IsRequired();
        }
    }
}
