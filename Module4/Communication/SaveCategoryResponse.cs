using Module4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }
        public SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
        }
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        public SaveCategoryResponse(string message) : this(false, message, null)
        { }

    }
}
