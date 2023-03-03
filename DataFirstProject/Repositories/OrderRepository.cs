using DataFirstProject.Models;
using DataFirstProject.ViewModels;

namespace DataFirstProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerWithOrdersViewModel GetCustomerOrdersByDate(int year)
        {
            var orders = _context.Orders.FirstOrDefault(x => x.OrderDate.Value.Year == year);
            var customerName = orders.Customer.ContactName;
            var employeeName = orders.Employee.FirstName;

            CustomerWithOrdersViewModel vm = new()
            {
                ContactName = customerName,
                FirstName = employeeName,
                OrderDate = orders.OrderDate.Value,
                Freight = orders.Freight.Value,
                OrderId = orders.OrderId,
            };
            return vm;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrdersByDate(int year)
        {
            return _context.Orders.Where(x => x.OrderDate!.Value.Year == year).ToList();
        }
    }
}
