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

        public IActionResult Index()
        {
            var orders = _orderRepository.GetOrders();
            return View(orders);
        }
    }
}
