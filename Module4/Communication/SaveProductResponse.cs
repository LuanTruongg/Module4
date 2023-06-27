using Module4.Models;

namespace Module4.Communication
{
        public class SaveProductResponse : BaseResponse
        {
            public Product product { get; private set; }
            public SaveProductResponse(bool success, string message, Product product) : base(success, message)
            {
            }
            public SaveProductResponse(Product product) : this(true, string.Empty, product)
            { }

            public SaveProductResponse(string message) : this(false, message, null)
            { }

        }    
}
