using Module4.Models;
using System.ComponentModel.DataAnnotations;

namespace Module4.Resource
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public short QuantityInPackage { get; set; }

        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }
    }
}
