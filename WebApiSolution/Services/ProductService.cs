using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product; 
        }

        public Product DeleteProduct(int id)
        {
            var product = _context.products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            throw new ProductException("product not found");
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                return product;
            }

            throw new ProductException("Product not found");
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.products
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();

            return products;
        } 

        public async Task<List<decimal>> GetTotalPriceOfProductsForEachCategory()
        {
            return await _context.products
                .GroupBy(x => x.CategoryId)
                .Select(x => x.Sum(p => p.Price))
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPriceOfProductsWithCategory(int categoryId)
        {
            return await _context.products
                .Where(x => x.CategoryId == categoryId)
                .SumAsync(x => x.Price);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var foundProduct = _context.products.FirstOrDefault(x => x.Id == id);
            if (foundProduct != null)
            {
                foundProduct.Name = product.Name;
                foundProduct.Price = product.Price;
                _context.SaveChanges();
                return foundProduct;
            }
            throw new ProductException("product not found");
        }
    }
}

