using DataFirstProject.Areas.BikeStore.Models;

namespace DataFirstProject.Areas.BikeStore.ViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products{ get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}
