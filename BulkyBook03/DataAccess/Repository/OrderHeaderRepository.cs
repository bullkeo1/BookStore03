using System.Linq;
using BulkyBook03.Models;
using BulkyBook03.DataAccess;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;

namespace BulkyBook03.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

           
        public void Update(OrderHeader orderHeader)
        {
            _db.Update(orderHeader);
        }
    }
}