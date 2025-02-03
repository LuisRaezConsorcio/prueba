using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using LibeyTechnicalTestDomain.EFCore.Configuration;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.EFCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<LibeyUser> LibeyUsers { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LibeyUserConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new UbigeoConfiguration());
        }
    }
}