using DemoAPI_List.Data;
using DemoAPI_List.Models;
using DemoAPI_List.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI_List.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context ,IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var product = _context.Products.Select(p => new Product()
            {
                Id = p.Id,
                NameProduct = p.NameProduct,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity   
            }).ToList();
            return product;
          //  return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var data = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return   data;
           // return await _productRepository.GetById(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var data = new Product()
            {
                Id = Guid.NewGuid(),
                NameProduct = product.NameProduct,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };
            _context.Products.Add(data);
            _context.SaveChanges();
            return data;
          //  return await _productRepository.Add(product);
        }

        public async Task<Product> UpdateProduct(Guid Id, Product model)
        {
            var product = GetProductById(Id);
            if (product == null)
                return null;
            product.Result.NameProduct = model.NameProduct;
            product.Result.Description = model.Description;
            product.Result.Quantity = model.Quantity;
            product.Result.Price = model.Price;

            _context.SaveChanges();
            return product.Result;
            // return await _productRepository.Update(product);
        }

        public async Task<string> DeleteProduct(Guid id)
        {
            var product = GetProductById(id);
            if (product == null)
                return null;
            _context.Remove(product.Result);
            _context.SaveChanges();
            return "delete product success!";
            //  return await _productRepository.Delete(id);
        }
    }
}
