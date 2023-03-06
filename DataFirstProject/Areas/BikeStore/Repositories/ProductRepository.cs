using DataFirstProject.Areas.BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DataFirstProject.Areas.BikeStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BikeStoresContext _context;

        public ProductRepository(BikeStoresContext context)
        {
            _context = context;
        }

        public void AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.Include(x => x.Brand).Include(x => x.Category).ToList();
            return products;
        }
    }
}
