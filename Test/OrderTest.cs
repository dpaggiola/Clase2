using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class OrderTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestMethod]
        public void TestGetSetName()
        {
            Order order = new Order();
            order.Name = "Juan";
        }
    }
}
