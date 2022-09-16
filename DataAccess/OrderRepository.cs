using System.Linq;
using Domain;
using IDataAccess;

namespace DataAccess
{
    public class OrderRepository: IOrderRepository
    {
        private ContextDb _context;
        public OrderRepository(ContextDb context)
        {
            this._context = context;
        }
        public Order Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Remove(Order entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}