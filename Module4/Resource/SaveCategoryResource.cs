using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4.Resource
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
