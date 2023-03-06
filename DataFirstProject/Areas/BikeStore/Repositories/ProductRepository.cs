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

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> ProductByYear(int year)
        {
            var products = _context.Products.FromSqlInterpolated($"usp_GetProductsByModelYear {year}").ToList();
            return products;
        }
    }
}
