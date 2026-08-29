using ECommerceApi.DTOs;
using ECommerceApi.Models;

namespace ECommerceApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(CreateProductDto createProductDto);

        Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto);


        Task<bool> DeleteProductAsync(int id);

    }
}
