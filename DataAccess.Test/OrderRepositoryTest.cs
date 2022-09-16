using Domain;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private ContextDb _dbContext;
        private DbContextOptions _dbOptions;

        [TestInitialize]
        public void Setup()
        {
            this._dbOptions = new DbContextOptionsBuilder<ContextDb>()
                .UseInMemoryDatabase("TacosDB").Options;
            this._dbContext = new ContextDb(this._dbOptions);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._dbContext.Database.EnsureDeleted();
        }

        private List<Order> LoadOrders()
        {
            List<Order> ordersToReturns = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    Name = "Papas Fritas",
                    Address = "Juan Gomez 6767",
                    PurchaseNumber = 1,
                    Price = 100
                },
                new Order()
                {
                    Id = 2,
                    Name = "Milanesas",
                    Address = "Juan Gomez 6767",
                    PurchaseNumber = 1,
                    Price = 150
                }
            };

            ordersToReturns.ForEach(order => this._dbContext.Orders.Add(order));
            this._dbContext.SaveChanges();

            return ordersToReturns;
        }

        [TestMethod]
        public void TestGetAllOrdersOk()
        {
            List<Order> ordersToReturn = LoadOrders();
            var repository = new OrderRepository(this._dbContext);
            var result = repository.GetAll();

            Assert.IsTrue(ordersToReturn.SequenceEqual(result));           
        }
    }
}
