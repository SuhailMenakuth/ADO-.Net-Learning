using EF_Day_4.Models;
using EF_Day_4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Day_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServicecs _productService;

        public ProductController(IProductServicecs productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching products", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while fetching product with ID {id}", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                var createdProduct = await _productService.AddProductAsync(product);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the product", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(id, product);
                if (updatedProduct == null) return NotFound();
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while updating product with ID {id}", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var success = await _productService.DeleteProduct(id);
                if (!success) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while deleting product with ID {id}", Details = ex.Message });
            }
        }

        [HttpGet("filter/{price}")]
        public async Task<IActionResult> FilterProductsByPrice(decimal price)
        {
            try
            {
                var products = await _productService.FilterProductsByPriceAsync(price);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while filtering products", Details = ex.Message });
            }
        }

    }
}
