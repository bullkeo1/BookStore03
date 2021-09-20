using System.Linq;
using BulkyBook03.Models;
using BulkyBook03.DataAccess;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;

namespace BulkyBook03.DataAccess.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(OrderDetails orderDetails)
        {
            _db.Update(orderDetails);
        }
    }
}