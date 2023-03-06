using DataFirstProject.Models;
using DataFirstProject.ViewModels;

namespace DataFirstProject.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        List<Product> GetProductsByPrice(decimal price);

        (List<ProductViewModel> prd, List<OrderViewModel> ord) GetData();
    }
}
