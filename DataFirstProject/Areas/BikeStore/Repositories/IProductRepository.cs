using DataFirstProject.Areas.BikeStore.Models;

namespace DataFirstProject.Areas.BikeStore.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        List<Brand> GetBrands();

        List<Category> GetCategories(); 

        void AddBrand(Brand brand);

        void AddCategory(Category category);
    }
}
