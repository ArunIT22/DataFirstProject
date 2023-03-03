using DataFirstProject.Models;

namespace DataFirstProject.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrdersByDate(int year);

    }
}
