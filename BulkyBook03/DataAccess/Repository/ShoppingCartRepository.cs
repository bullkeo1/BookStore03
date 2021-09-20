using System.Linq;
using BulkyBook03.Models;
using BulkyBook03.DataAccess;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;

namespace BulkyBook03.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ShoppingCart shoppingCart)
        {
            _db.Update(shoppingCart);
        }
    }
    }
