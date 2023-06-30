using Module4.Communication;
using Module4.Models;
using Module4.Repositories;
using System;

namespace Module4.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRespository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRespository, IUnitOfWork unitOfWork)
        {
            _categoryRespository = categoryRespository;
            _unitOfWork = unitOfWork;
        }

        

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRespository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRespository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id,Category category)
        {
            
            var existingCategory = await _categoryRespository.FindByIdAsync(id);
            if (existingCategory == null)            
                return new SaveCategoryResponse("Category not found.");
            
            existingCategory.Name = category.Name;
            try
            {
                _categoryRespository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRespository.FindByIdAsync(id);
            if (existingCategory == null)
                return new SaveCategoryResponse("Category not found.");

            try
            {
                _categoryRespository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
