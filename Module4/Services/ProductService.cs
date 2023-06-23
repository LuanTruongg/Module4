using Module4.Models;
using Module4.Repositories;

namespace Module4.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRespository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRespository, IUnitOfWork unitOfWork)
        {
            _productRespository = productRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRespository.ListAsync();
        }
    }
}
