using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4.Models;

namespace Module4.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories"); // Install Nuget microsoft.aspnetcore.identity.entityframeworkcore

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.HasMany(c => c.Products).WithOne(c => c.Category).HasForeignKey(c => c.Id);
        }
    }
}
