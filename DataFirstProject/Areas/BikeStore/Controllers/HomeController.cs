using DataFirstProject.Areas.BikeStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataFirstProject.Areas.BikeStore.Controllers
{
    [Area("BikeStore")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _repos;

        public HomeController(IProductRepository repos)
        {
            _repos = repos;
        }

        //[Route("BikeStore/Home/Index")]
        public IActionResult Index(int year = 0)
        {
            if (year == 0)
            {
                var data = _repos.GetProducts();
                return View(data);
            }
            else
            {
                var datas = _repos.ProductByYear(year);
                return View(datas);
            }
        }


    }
}
