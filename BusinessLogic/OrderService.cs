using System.Linq;
using Domain;
using IBusinessLogic;
using IDataAccess;

namespace BusinessLogic
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            this._repository = repository;
        }

        public Order Create(Order order)
        {
            Order createdOrder = _repository.Add(order);
            return createdOrder;
        }

        public void Delete(Order order)
        {
            _repository.Remove(order);
        }

        public IQueryable<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Order order)
        {
            _repository.Update(order);
        }
    }
}