using System.Linq;
using Domain;

namespace IDataAccess
{
    public interface IOrderRepository
    {
        void Add (Order entity);
        void Remove (Order entity);
        void Update (Order entity);
        IQueryable<Order> GetAll();
    }
}