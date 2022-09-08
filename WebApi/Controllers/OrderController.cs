using System.Linq;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrderController: ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IQueryable<Order> orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Order order)
        {
            _orderService.Create(order);
            return Created("", order);
        }
    }
}