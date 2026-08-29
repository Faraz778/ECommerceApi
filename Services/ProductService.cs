using ECommerceApi.Data;
using ECommerceApi.DTOs;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Services
{
    public class ProductService : IProductService
    {
      private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();

            return products;
        }


        public async Task<Product?> GetProductByIdAsync(int id)
        {

            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }


        // create product
        public async Task<Product> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                ProductName = createProductDto.ProductName,
                ProductPrice = createProductDto.ProductPrice,
                CategoryId = createProductDto.CategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            product.ProductName = updateProductDto.ProductName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }









    }
}
