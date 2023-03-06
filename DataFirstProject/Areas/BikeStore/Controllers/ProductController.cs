using DataFirstProject.Areas.BikeStore.Models;
using DataFirstProject.Areas.BikeStore.Repositories;
using DataFirstProject.Areas.BikeStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DataFirstProject.Areas.BikeStore.Controllers
{
    [Area("BikeStore")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [Route("BikeStore/Product")]
        [Route("BikeStore/Product/Index")]
        public IActionResult Index()
        {
            ProductsViewModel vm = new()
            {
                Products = _repository.GetProducts(),
                Brands = _repository.GetBrands(),
                Categories = _repository.GetCategories()
            };
            return View(vm);
        }

        [HttpPost]
        [Route("BikeStore/Product/AddBrand")]
        public IActionResult AddBrand(Brand brand)
        {
            _repository.AddBrand(brand);

            ProductsViewModel vm = new()
            {
                Products = _repository.GetProducts(),
                Brands = _repository.GetBrands(),
                Categories = _repository.GetCategories()
            };
            return View("Index",vm);
        }

        [HttpPost]
        [Route("BikeStore/Product/AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            _repository.AddCategory(category);

            ProductsViewModel vm = new()
            {
                Products = _repository.GetProducts(),
                Brands = _repository.GetBrands(),
                Categories = _repository.GetCategories()
            };
            return View("Index",vm);
        }
    }
}
