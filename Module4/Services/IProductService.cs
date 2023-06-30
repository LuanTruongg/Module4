using Module4.Communication;
using Module4.Models;
using Module4.Resource;

namespace Module4.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> GetById(int id);
        Task<SaveProductResponse> SaveAsync(Product product);
        Task<SaveProductResponse> UpdateAsync(int id, Product product);
        Task<SaveProductResponse> DeleteAsync(int id);
    }
}
