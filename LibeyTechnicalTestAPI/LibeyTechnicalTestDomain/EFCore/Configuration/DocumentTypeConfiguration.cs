using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType");
            builder.HasKey(x => x.DocumentTypeId);

            builder.Property(x => x.DocumentTypeId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DocumentTypeDescription)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
