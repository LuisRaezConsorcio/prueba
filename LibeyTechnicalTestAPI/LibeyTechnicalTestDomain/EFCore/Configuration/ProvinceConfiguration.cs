using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");
            builder.HasKey(x => x.ProvinceCode);

            builder.Property(x => x.ProvinceCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(x => x.RegionCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.ProvinceDescription)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne<Region>()
                .WithMany()
                .HasForeignKey(x => x.RegionCode)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
