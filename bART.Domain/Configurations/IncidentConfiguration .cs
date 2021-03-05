using bART.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bART.Domain.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<IncidentEntity>
    {
        public void Configure(EntityTypeBuilder<IncidentEntity> builder)
        {
            builder.HasKey(e => e.Name);
            builder.Property(e => e.Name).ValueGeneratedOnAdd();
            builder.HasMany(e => e.Accounts)
                .WithOne(incident => incident.Incident)
                .HasForeignKey(e => e.IncidentName)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
