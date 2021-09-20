using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;

namespace BulkyBook03.DataAccess.Repository
{
    public class ApplicationUserRepository :Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}