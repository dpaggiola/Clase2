using System;
using System.Linq;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/Orders")]
    public class OrderController : ControllerBase
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
        [ServiceFilter(typeof(FilterAuthentication))]
        [ProtectFilter(RoleType.Admin)]
        public ActionResult Add([FromBody] Order order)
        {
            try
            {
                Order createOrder = _orderService.Create(order);
                return CreatedAtRoute("AddOrder", new OrderBasicInfoModel()
                {
                    Id = createOrder.Id,
                    DeliveryDateTime = createOrder.DeliveryDateTime
                });
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}