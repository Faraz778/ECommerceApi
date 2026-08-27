using ECommerceApi.DTOs;
using ECommerceApi.Models;

namespace ECommerceApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task<Category?> GetCategoryByIdAsync(int id);

        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
