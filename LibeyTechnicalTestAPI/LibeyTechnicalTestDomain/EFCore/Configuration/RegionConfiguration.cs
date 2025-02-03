using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.HasKey(x => x.RegionCode);

            builder.Property(x => x.RegionCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.RegionDescription)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
