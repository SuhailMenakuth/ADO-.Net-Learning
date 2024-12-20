using EF_Day_4.Models;

namespace EF_Day_4.Services
{
    public interface IProductServicecs
    {
       Task<IEnumerable<Product>> GetAllProductsAsync();
       Task<Product> GetProductByIdAsync(int id);
       Task<Product> AddProductAsync(Product product);
       Task<Product> UpdateProductAsync(int id, Product product);
       Task<bool> DeleteProduct(int id);
       Task<IEnumerable<Product>> FilterProductsByPriceAsync(decimal price);

    }
}
