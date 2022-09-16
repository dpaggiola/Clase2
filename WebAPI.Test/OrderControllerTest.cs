using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WebApi;

namespace WebAPI.Test
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void CreateValidOrderTest()
        {
            Order order = new Order()
            {
                Name = "Papas Fritas",
                Address = "Juan Gomez 3878",
                Price = 100,
                PurchaseNumber = 2,
                DeliveryDateTime = DateTime.Now.AddHours(1)
            };

            OrderBasicInfoModel expectedOrder = new OrderBasicInfoModel()
            {
                Id = order.Id,
                DeliveryDateTime = order.DeliveryDateTime
            };

            var mock = new Mock<IOrderService>(MockBehavior.Strict);
            mock.Setup(orderService => orderService.Create(It.IsAny<Order>())).Returns(order);

            var controller = new OrderController(mock.Object);
            var result = controller.Add(order);
            var createdResult = result as CreatedAtRouteResult;
            var model = createdResult.Value as OrderBasicInfoModel;

            mock.VerifyAll();
            Assert.IsTrue(model.Id == expectedOrder.Id);
        }

        [TestMethod]
        public void CreateInvalidOrderTest()
        {
            var mock = new Mock<IOrderService>(MockBehavior.Strict);
            mock.Setup(orderService => orderService.Create(null)).Throws(new ArgumentException());

            var controller = new OrderController(mock.Object);
            var result = controller.Add(null);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
