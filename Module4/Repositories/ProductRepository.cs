using Microsoft.EntityFrameworkCore;
using Module4.Data;
using Module4.Models;

namespace Module4.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.AddAsync(product);
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public void PutAsync(Product product)
        {
            _context.Products.Update(product);
        }

        public void RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
