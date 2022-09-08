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

        public void Create(Order order)
        {
            _repository.Add(order);
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