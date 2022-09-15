using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestGetSetName()
        {
            Order order = new Order();
            order.Name = "Juan";
        }
    }
}
