using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProductsByCategory(int categoryId);
        public Task<Decimal> GetTotalPriceOfProductsWithCategory(int categoryId);
        public Task<List<Decimal>> GetTotalPriceOfProductsForEachCategory();
        public Task<Product> AddProduct(Product product);
        public Product UpdateProduct(int id, Product product);
        public Product DeleteProduct(int id);
    }
}
