using Module4.Communication;
using Module4.Models;
using Module4.Repositories;
using Module4.Resource;

namespace Module4.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRespository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRespository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _productRespository = productRespository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<SaveProductResponse> DeleteAsync(int id)
        {
            var product = await _productRespository.GetById(id);
            if (product == null)
                return new SaveProductResponse($"The Product with id: {id} does not exist");
            try
            {
                _productRespository.RemoveAsync(product);
                await _unitOfWork.CompleteAsync();
                return new SaveProductResponse(product);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"An error occurred when saving the product: {ex.Message}");
            }
            
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRespository.GetById(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRespository.ListAsync();
        }

        public async Task<SaveProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRespository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new SaveProductResponse(product);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<SaveProductResponse> UpdateAsync(int id , Product product)
        {
            var editProduct = await _productRespository.GetById(id);
            if (editProduct == null)
                return new SaveProductResponse($"The Product with id: {id} does not exist");
            editProduct.Name = product.Name;
            editProduct.QuantityInPackage = product.QuantityInPackage;
            editProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            editProduct.CategoryId = product.CategoryId;
            try
            {
                _productRespository.PutAsync(editProduct);
                await _unitOfWork.CompleteAsync();
                return new SaveProductResponse(product);
            }
            catch (Exception ex)
            {
                return new SaveProductResponse($"An error occurred when update the product: {ex.Message}");
            }
        }
    }
}
