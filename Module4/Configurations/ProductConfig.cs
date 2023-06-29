using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4.Models;

namespace Module4.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.UnitOfMeasurement).IsRequired();
            builder.Property(x => x.QuantityInPackage).IsRequired();
            builder.HasOne(x=>x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
