using DataFirstProject.Areas.BikeStore.Models;

namespace DataFirstProject.Areas.BikeStore.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        List<Product> ProductByYear(int year);
    }
}
