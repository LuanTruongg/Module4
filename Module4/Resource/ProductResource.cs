using Module4.Models;
using System.ComponentModel.DataAnnotations;

namespace Module4.Resource
{
    public class ProductResource
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryResource Category { get; set; }
    }
}
