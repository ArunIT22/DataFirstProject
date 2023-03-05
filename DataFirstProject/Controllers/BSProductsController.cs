using DataFirstProject.Models.BikeStores;
using DataFirstProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataFirstProject.Controllers
{
    //[Route("BikeStore/BSProducts")]
    //[Route("BikeStore/BSProducts/Index")]
    public class BSProductsController : Controller
    {
        private readonly BikeStoresContext _context;

        public BSProductsController(BikeStoresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = this.LoadData();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult AddBrand(string brandName)
        {
            var vm = this.LoadData();
            if (ModelState.IsValid)
            {
                _context.Brands.Add(new Brand { BrandName = brandName });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult AddCategory(string categoryName)
        {
            var vm = this.LoadData();
            if (ModelState.IsValid)
            {
                _context.Categories.Add(new Category { CategoryName = categoryName });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", vm);
        }

        [NonAction]
        public BSCustomerProductVM LoadData()
        {
            var products = _context.Products.Include(x => x.Brand).Include(x => x.Category).ToList();
            BSCustomerProductVM vm = new()
            {
                Customers = _context.Customers.ToList(),
                Products = products,
            };
            return vm;
        }
    }
}
