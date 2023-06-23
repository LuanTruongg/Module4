using Module4.Communication;
using Module4.Models;

namespace Module4.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
        Task<SaveCategoryResponse> UpdateAsync(int id , Category category);
        Task<SaveCategoryResponse> DeleteAsync(int id);
    }
}
