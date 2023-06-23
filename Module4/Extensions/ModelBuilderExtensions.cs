using Microsoft.EntityFrameworkCore;
using Module4.Models;

namespace Module4.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 100, Name = "Fruits and Vegetables" },
                new Category() { Id = 101, Name = "Dairy" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                 new Product
                 {
                     Id = 101,
                     Name = "Milk",
                     QuantityInPackage = 2,
                     UnitOfMeasurement = EUnitOfMeasurement.Liter,
                     CategoryId = 101,
                 }
                );
        }
    }
}
