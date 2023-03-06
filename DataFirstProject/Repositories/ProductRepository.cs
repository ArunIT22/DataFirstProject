using DataFirstProject.Models;
using DataFirstProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DataFirstProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            // GetData();
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

        public (List<ProductViewModel> prd, List<OrderViewModel> ord) GetData()
        {
            var connection = _context.Database.GetDbConnection();

            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "usp_MultipleTable";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var reader = cmd.ExecuteReader();
            var products = new List<ProductViewModel>();
            var orders = new List<OrderViewModel>();

            while (reader.Read())
            {
                orders.Add(new OrderViewModel
                {
                    OrderId = int.Parse(reader["OrderId"].ToString()),
                    OrderDate = DateTime.Parse(reader["OrderDate"].ToString())
                });
            }

            reader.NextResult();

            while (reader.Read())
            {
                products.Add(new ProductViewModel
                {
                    ProductId = int.Parse(reader["ProductId"].ToString()),
                    ProductName = reader["ProductName"].ToString(),
                    UnitPrice = decimal.Parse(reader["UnitPrice"].ToString())
                });

            }

            return (products, orders);

        }


    }
}
