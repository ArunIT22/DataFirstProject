using DataFirstProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataFirstProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(decimal price = 0)
        {
            if (price == 0)
            {
                var products = _repository.GetProducts();
                return View(products);
            }
            else
            {
                var products = _repository.GetProductsByPrice(price);
                return View(products);  
            }
        }
    }
}
