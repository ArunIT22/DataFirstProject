using DataFirstProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataFirstProject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index(int? year = null)
        {
            if (year.HasValue)
            {
               var orderByYear = _orderRepository.GetOrdersByDate(year.Value);
                return View(orderByYear);
            }
            var orders = _orderRepository.GetOrders();
            return View(orders);
        }

        public IActionResult CustomerWithOrderByDate(int? year = null)
        {
           var vm = _orderRepository.GetCustomerOrdersByDate(1997);
            return View("CustomerOrders",vm);
        }
    }
}
