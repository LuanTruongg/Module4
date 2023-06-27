using Module4.Communication;
using Module4.Models;
using Module4.Resource;

namespace Module4.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> GetById(int id);
        Task AddAsync(Product product);
        void PutAsync(Product product);
        void RemoveAsync(Product product);
    }
}
