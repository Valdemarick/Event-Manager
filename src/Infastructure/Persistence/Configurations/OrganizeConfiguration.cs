using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Persistence.Configurations
{
    public class OrganizeConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityAlwaysColumn().ValueGeneratedOnAdd();

            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(o => o.Id).IsUnique();
        }
    }
}