using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Get All Products

        [HttpGet("/products")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        // Get Product by ID

        [HttpGet("/products/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }

        // Get total price of all products by Category IDs

        [HttpGet("/products/prices")]
        public async Task<List<Decimal>> GetTotalPriceOfProductsForEachCategory()
        {
            return await _productService.GetTotalPriceOfProductsForEachCategory();
        }

        // Get Total price of products with CategoryId
        [HttpGet("/products/prices/category{id}")]
        public async Task<Decimal> GetTotalPriceOfProductsWithCategory(int id)
        {
            return await _productService.GetTotalPriceOfProductsWithCategory(id);

        }

        // Add new product
        [HttpPost("/products")]
        public async Task<Product> AddProduct([FromBody] Product product)
        {
            return await _productService.AddProduct(product);
        }

        //Update product by id
        [HttpPut("products/{id}")]
        public Product UpdateProduct(int id, [FromBody] Product product)
        {
            return _productService.UpdateProduct(id, product);
        }

        //Delete product by Id
        [HttpDelete("/products/{id}")]
        public Product DeleteProductById(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}