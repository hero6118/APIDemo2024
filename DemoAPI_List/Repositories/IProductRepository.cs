using DemoAPI_List.Models;

namespace DemoAPI_List.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
    }
}
