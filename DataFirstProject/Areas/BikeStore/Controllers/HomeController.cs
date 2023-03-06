using DataFirstProject.Areas.BikeStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataFirstProject.Areas.BikeStore.Controllers
{
    [Area("BikeStore")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [Route("BikeStore")]
        [Route("BikeStore/Home")]
        [Route("BikeStore/Home/Index")]      
        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            return View(products);
        }
    }
}
