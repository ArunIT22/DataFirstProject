using DataFirstProject.Models;
using DataFirstProject.ViewModels;

namespace DataFirstProject.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrdersByDate(int year);

        CustomerWithOrdersViewModel GetCustomerOrdersByDate(int year);
    }
}
