using DataFirstProject.Models;

namespace DataFirstProject.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        List<Product> GetProductsByPrice(decimal price);
    }
}
