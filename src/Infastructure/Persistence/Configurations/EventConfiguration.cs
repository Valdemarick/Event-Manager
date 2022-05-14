using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityAlwaysColumn().ValueGeneratedOnAdd();

            builder.Property(e => e.Date).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(300);
        }
    }
}