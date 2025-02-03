using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeo");
            builder.HasKey(x => x.UbigeoCode);

            builder.Property(x => x.UbigeoCode)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(x => x.ProvinceCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(x => x.RegionCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.UbigeoDescription)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne<Province>() 
                .WithMany() 
                .HasForeignKey(x => x.ProvinceCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Region>()
                .WithMany()
                .HasForeignKey(x => x.RegionCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
