using DataFirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataFirstProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductsByPrice(decimal price)
        {
            var products = _context.Products.FromSqlInterpolated($"usp_GetProductsByPrice {price}").ToList(); //usp_GetProductsByPrice @price
            return products;
        }
    }
}
