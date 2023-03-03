using DataFirstProject.Models;

namespace DataFirstProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrdersByDate(int  year)
        {
            return _context.Orders.Where(x => x.OrderDate.Value.Year == year).ToList();
        }
    }
}
