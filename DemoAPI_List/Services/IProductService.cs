using DemoAPI_List.Models;

namespace DemoAPI_List.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Guid Id,Product product);
        Task<string> DeleteProduct(Guid id);
    }
}
