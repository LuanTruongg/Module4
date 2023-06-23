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
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
