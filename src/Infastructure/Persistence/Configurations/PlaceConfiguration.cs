using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Persistence.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityAlwaysColumn().ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}