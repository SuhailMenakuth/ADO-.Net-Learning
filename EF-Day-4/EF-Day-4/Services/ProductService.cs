using EF_Day_4.Data;
using EF_Day_4.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Day_4.Services
{
    public class ProductService : IProductServicecs
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return _context.Products.Find(id);
        }


        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
           var existingProduct =  await _context.Products.FindAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.ManufactureDate = product.ManufactureDate;

            await _context.SaveChangesAsync();
            return existingProduct;

        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
            {
                
            }
        }
        public async Task<IEnumerable<Product>> FilterProductsByPriceAsync(decimal price)
        {
            return await _context.Products.Where(p => p.Price >= price).ToListAsync();
        }
       
    }
}
